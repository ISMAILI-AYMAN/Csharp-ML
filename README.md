# SimpleMlApp - Housing Price Prediction

A machine learning application built with ML.NET that predicts median house values based on California housing data.

## Overview

This project demonstrates regression analysis using Microsoft's ML.NET framework. It trains a FastTree regression model to predict housing prices based on various features such as location, property characteristics, and demographic information.

## Features

- **Data Loading**: Reads housing data from CSV format
- **Model Training**: Uses FastTree regression algorithm
- **Data Preprocessing**: Feature concatenation and min-max normalization
- **Model Evaluation**: Calculates RMSE and R² metrics
- **Model Persistence**: Saves and loads trained models
- **Prediction Engine**: Makes predictions on new housing data

## Prerequisites

- .NET 10.0 SDK or later
- Microsoft.ML (v5.0.0)
- Microsoft.ML.FastTree (v5.0.0)

## Project Structure

```
SimpleMlApp/
├── Program.cs           # Main application code
├── SimpleMlApp.csproj   # Project configuration
├── data.csv             # Training dataset
└── model.zip            # Trained model (generated)
```

## Dataset

The application uses California housing data with the following features:

| Feature | Description |
|---------|-------------|
| Longitude | Longitude coordinate |
| Latitude | Latitude coordinate |
| HousingMedianAge | Median age of houses in the block |
| TotalRooms | Total number of rooms |
| TotalBedrooms | Total number of bedrooms |
| Population | Block population |
| Households | Number of households |
| MedianIncome | Median income of households |
| **MedianHouseValue** | **Target variable to predict** |
| OceanProximity | Categorical feature (proximity to ocean) |

## Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd SimpleMlApp
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

## Usage

Run the application:
```bash
dotnet run --project SimpleMlApp
```

The application will:
1. Load the housing data from `data.csv`
2. Split data into training (80%) and test (20%) sets
3. Train a FastTree regression model
4. Evaluate model performance
5. Save the trained model to `model.zip`
6. Load the model and make a sample prediction

### Sample Output

```
RMSE: <root mean squared error>
R^2: <coefficient of determination>
Predicted Median House Value: <predicted value>
```

## Model Architecture

**Pipeline Steps:**
1. **Feature Engineering**: Concatenates numerical features into a single feature vector
2. **Normalization**: Applies min-max normalization to features
3. **Training**: Uses FastTree algorithm for regression

**Algorithm**: FastTree (Fast Gradient Boosting Decision Tree)

## Code Example

Making predictions with a trained model:

```csharp
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
```

## Model Evaluation Metrics

- **RMSE (Root Mean Squared Error)**: Measures the average prediction error
- **R² (Coefficient of Determination)**: Indicates how well the model fits the data (0 to 1, higher is better)

## Customization

To modify the model or features:

1. **Change the algorithm**: Replace `FastTree` with other regression trainers (e.g., `Sdca`, `LbfgsPoissonRegression`)
2. **Add features**: Include additional columns in the feature concatenation
3. **Adjust hyperparameters**: Configure the FastTree trainer with custom parameters
4. **Modify split ratio**: Change `testFraction` parameter in `TrainTestSplit`

## License

[Add your license here]

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Acknowledgments

- Built with [ML.NET](https://dotnet.microsoft.com/apps/machinelearning-ai/ml-dotnet)
- California housing dataset
