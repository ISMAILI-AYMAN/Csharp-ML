using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

// ---------- Data Classes ----------
public class HousingData
{
    [LoadColumn(0)]
    public float Longitude { get; set; }

    [LoadColumn(1)]
    public float Latitude { get; set; }

    [LoadColumn(2)]
    public float HousingMedianAge { get; set; }

    [LoadColumn(3)]
    public float TotalRooms { get; set; }

    [LoadColumn(4)]
    public float TotalBedrooms { get; set; }

    [LoadColumn(5)]
    public float Population { get; set; }

    [LoadColumn(6)]
    public float Households { get; set; }

    [LoadColumn(7)]
    public float MedianIncome { get; set; }

    [LoadColumn(8)]
    public float MedianHouseValue { get; set; }  // Target

    [LoadColumn(9)]
    public string OceanProximity { get; set; }   // Categorical
}

public class HousingPrediction
{
    [ColumnName("Score")]
    public float MedianHouseValue { get; set; }
}

// ---------- Program ----------
class Program
{
    static void Main(string[] args)
    {
        var mlContext = new MLContext();

        // Resolve data file path
        string? ResolveDataPath(string fileName)
        {
            var dir = AppContext.BaseDirectory;
            for (int i = 0; i < 4; i++)
            {
                var candidate = Path.Combine(dir, fileName);
                if (File.Exists(candidate)) return candidate;
                dir = Path.GetDirectoryName(dir) ?? dir;
            }
            return null;
        }

        var dataFile = ResolveDataPath("data.csv");
        if (dataFile == null)
            throw new FileNotFoundException($"File or directory does not exist at path: data.csv. Searched relative to: {AppContext.BaseDirectory}");

        // Load data
        var data = mlContext.Data.LoadFromTextFile<HousingData>(
            dataFile, separatorChar: ',', hasHeader: true);

        // Split data
        var split = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);

        // Pipeline
        var pipeline = mlContext.Transforms.Concatenate("Features",
                nameof(HousingData.Longitude),
                nameof(HousingData.Latitude),
                nameof(HousingData.HousingMedianAge),
                nameof(HousingData.TotalRooms),
                nameof(HousingData.TotalBedrooms),
                nameof(HousingData.Population),
                nameof(HousingData.Households),
                nameof(HousingData.MedianIncome))
            .Append(mlContext.Transforms.NormalizeMinMax("Features"))
            .Append(mlContext.Regression.Trainers.FastTree(
                labelColumnName: nameof(HousingData.MedianHouseValue),
                featureColumnName: "Features"));

        // Train model
        var trainedModel = pipeline.Fit(split.TrainSet);

        // Evaluate
        var predictions = trainedModel.Transform(split.TestSet);
        var metrics = mlContext.Regression.Evaluate(
            predictions,
            labelColumnName: nameof(HousingData.MedianHouseValue),
            scoreColumnName: "Score");

        Console.WriteLine($"RMSE: {metrics.RootMeanSquaredError}");
        Console.WriteLine($"R^2: {metrics.RSquared}");

        // Save model
        mlContext.Model.Save(trainedModel, split.TrainSet.Schema, "model.zip");

        // Load model and predict
        ITransformer loadedModel = mlContext.Model.Load("model.zip", out var schema);
        var predEngine = mlContext.Model.CreatePredictionEngine<HousingData, HousingPrediction>(loadedModel);

        var sample = new HousingData
        {
            Longitude = -122.23f,
            Latitude = 37.88f,
            HousingMedianAge = 41f,
            TotalRooms = 880f,
            TotalBedrooms = 129f,
            Population = 322f,
            Households = 126f,
            MedianIncome = 8.3252f
        };

        var result = predEngine.Predict(sample);
        Console.WriteLine($"Predicted Median House Value: {result.MedianHouseValue:0.00}");
    }
}
