# Simple ML App

SimpleMlApp is a minimal end-to-end regression example built with **ML.NET 5.0**. It trains a FastTree gradient-boosted decision tree to predict California housing prices from tabular data, reports basic regression metrics, writes the trained model to `model.zip`, and issues a sample prediction.

## Prerequisites

- .NET SDK 10.0 (Preview) or newer (`dotnet --info` should list `net10.0` support).
- The included `SimpleMlApp/data.csv` file (derived from the California Housing dataset). Each row must contain:
  1. `Longitude`
  2. `Latitude`
  3. `HousingMedianAge`
  4. `TotalRooms`
  5. `TotalBedrooms`
  6. `Population`
  7. `Households`
  8. `MedianIncome`
  9. `MedianHouseValue` (label)
  10. `OceanProximity` (categorical string, currently unused in the pipeline)

## Getting Started

```bash
cd SimpleMlApp
dotnet restore
dotnet run
```

You should see console output similar to:

```
RMSE: 52693.42
R^2: 0.76
Predicted Median House Value: 234567.89
```

The exact values depend on the random train/test split.

## How It Works

- `Program.cs` defines the `HousingData` schema and assembles the ML.NET pipeline.
- Features are concatenated and normalized via `NormalizeMinMax`.
- `FastTreeRegressionTrainer` fits on 80% of the data and evaluates on the remaining 20%.
- The trained model is saved to `model.zip`, then reloaded to score a hard-coded sample.

## Customizing

- **Different trainer:** swap `mlContext.Regression.Trainers.FastTree` with any other ML.NET regression trainer.
- **Feature engineering:** add transforms before `Concatenate`, e.g., one-hot encode `OceanProximity`.
- **Deployment:** reference `model.zip` from another .NET app and use `CreatePredictionEngine` or `PredictionEnginePool`.

## Project Layout

- `SimpleMlApp/Program.cs` – main entry point and ML pipeline.
- `SimpleMlApp/data.csv` – source dataset loaded at runtime.
- `SimpleMlApp/model.zip` – generated after a successful run.
- `SimpleMlApp/bin` / `obj` – build outputs (ignored in git).

## Troubleshooting

- **`FileNotFoundException` for `data.csv`:** the app searches upward from `AppContext.BaseDirectory`. Run commands from the repo root or place `data.csv` next to the compiled binary.
- **SDK mismatch:** if `dotnet run` complains about `net10.0`, install the latest preview from https://dot.net or lower the `TargetFramework` in `SimpleMlApp.csproj`.

Happy experimenting!
