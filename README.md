## Simple ML App

Minimal end‑to‑end regression example built with ML.NET (`Microsoft.ML` 5.0). The app trains a FastTree gradient boosting model against the classic California Housing dataset, evaluates it, persists the trained pipeline to `model.zip`, and produces a single point prediction.

### Project Layout
- `SimpleMlApp/Program.cs` – data contracts, training pipeline, evaluation, and sample prediction.
- `SimpleMlApp/data.csv` – source dataset (expects the header/column order listed below).
- `SimpleMlApp/model.zip` – artifact written after a run; safe to delete and regenerate.
- `SimpleMlApp/SimpleMlApp.csproj` – .NET executable targeting `net10.0`.

### Housing Data Schema
| Column | Type | Notes |
| --- | --- | --- |
| `Longitude` | float | Geographic coordinate |
| `Latitude` | float | Geographic coordinate |
| `HousingMedianAge` | float | Years |
| `TotalRooms` | float | Count per block |
| `TotalBedrooms` | float | Count per block |
| `Population` | float | Residents per block |
| `Households` | float | Number of households |
| `MedianIncome` | float | Normalized income |
| `MedianHouseValue` | float | **Label** – target dollar value |
| `OceanProximity` | string | Categorical, currently unused |

### Prerequisites
- .NET SDK capable of building `net10.0` (preview SDKs already support it).
- A terminal with access to `dotnet` and the repo contents.

### Getting Started
1. **Restore & build**
   ```bash
   cd SimpleMlApp
   dotnet build
   ```
2. **Run training + evaluation**
   ```bash
   dotnet run
   ```
   The program will:
   - Resolve `data.csv` from the project/output directory.
   - Split the data 80/20 (train/test).
   - Train a FastTree regression model with min-max normalization.
   - Print RMSE and R² scores to stdout.
   - Persist the fitted pipeline to `model.zip`.
3. **Inspect output**
   - `model.zip` is regenerated each run and can be loaded in other apps via `MLContext.Model.Load`.
   - Console output ends with a sample prediction for a hard-coded block of features.

### Customization Tips
- **Changing features**: edit the `Concatenate` call in `Program.cs` to add/remove columns. Make sure the data schema class stays in sync with `data.csv`.
- **Using `OceanProximity`**: add a categorical transform, e.g., `.Append(mlContext.Transforms.Categorical.OneHotEncoding("OceanProximityEncoded", nameof(HousingData.OceanProximity)))` and include it in `Features`.
- **Different trainers**: swap `FastTree` for another ML.NET regression trainer to compare metrics.
- **New predictions**: replace the `sample` object near the bottom of `Program.cs` or expose an input path/CLI args.

### Troubleshooting
- `FileNotFoundException` for `data.csv`: ensure the dataset lives next to the executable (`SimpleMlApp/bin/Debug/net10.0/`) or in the project root; the helper searches upward four directories from `AppContext.BaseDirectory`.
- Missing .NET SDK preview: install the latest SDK from <https://dotnet.microsoft.com/en-us/download/dotnet>.

### Next Steps
- Wrap the training logic into reusable services or unit-testable methods.
- Add CLI options (e.g., fraction split, output path).
- Introduce automated evaluation or plotting for richer insights.
