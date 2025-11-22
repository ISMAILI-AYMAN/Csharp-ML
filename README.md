# California Housing Price Prediction

A machine learning application built with ML.NET that predicts median housing prices in California using various property and demographic features.

## 📊 Overview

This C# application uses Microsoft's ML.NET framework to train a regression model on California housing data. The model predicts median house values based on features such as location, age of housing, number of rooms, population, and median income of the area.

## ✨ Features

- **Data Processing**: Loads and processes California housing dataset from CSV
- **Model Training**: Uses FastTree regression algorithm for training
- **Model Evaluation**: Calculates RMSE and R-squared metrics
- **Model Persistence**: Saves trained model to disk for reuse
- **Prediction Engine**: Makes predictions on new housing data

## 🔧 Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet) or later
- Visual Studio 2022, Visual Studio Code, or any C# IDE (optional)

## 📦 Installation

1. Clone this repository:
```bash
git clone <repository-url>
cd c#ml
```

2. Restore NuGet packages:
```bash
cd SimpleMlApp
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

## 🚀 Usage

### Running the Application

```bash
dotnet run
```

The application will:
1. Load the housing data from `data.csv`
2. Split data into training (80%) and testing (20%) sets
3. Train a FastTree regression model
4. Evaluate model performance on test data
5. Save the trained model to `model.zip`
6. Make a sample prediction

### Expected Output

```
RMSE: <root-mean-squared-error>
R^2: <r-squared-score>
Predicted Median House Value: <predicted-value>
```

## 📊 Dataset

The California housing dataset contains information from the 1990 California census. Each row represents a census block group with the following features:

| Feature | Description | Type |
|---------|-------------|------|
| `longitude` | Longitude coordinate | Float |
| `latitude` | Latitude coordinate | Float |
| `housing_median_age` | Median age of houses in the block | Float |
| `total_rooms` | Total number of rooms in the block | Float |
| `total_bedrooms` | Total number of bedrooms in the block | Float |
| `population` | Total population in the block | Float |
| `households` | Total number of households | Float |
| `median_income` | Median income for households (in tens of thousands of USD) | Float |
| `median_house_value` | Median house value (target variable) | Float |
| `ocean_proximity` | Location relative to the ocean | String (categorical) |

## 🤖 Model Details

### Algorithm
- **FastTree**: A gradient boosting algorithm optimized for regression tasks
- Excellent for handling non-linear relationships and interactions between features

### Feature Engineering
1. **Feature Concatenation**: Combines numerical features into a single feature vector
2. **Normalization**: Min-Max normalization applied to standardize feature scales

### Pipeline Steps
1. Concatenate numerical features
2. Normalize features using Min-Max normalization
3. Train FastTree regression model

## 📁 Project Structure

```
c#ml/
├── c#ml.sln                     # Solution file
├── README.md                     # This file
└── SimpleMlApp/
    ├── SimpleMlApp.csproj        # Project file with dependencies
    ├── Program.cs                # Main application code
    ├── data.csv                  # California housing dataset
    └── model.zip                 # Saved trained model (generated)
```

## 📈 Performance Metrics

The model is evaluated using:
- **RMSE (Root Mean Squared Error)**: Measures average prediction error
- **R² (R-Squared)**: Indicates the proportion of variance explained by the model

## 💻 Sample Prediction

The application includes a sample prediction for a property with these characteristics:
- Longitude: -122.23
- Latitude: 37.88
- Housing Median Age: 41 years
- Total Rooms: 880
- Total Bedrooms: 129
- Population: 322
- Households: 126
- Median Income: $83,252

## 🛠️ Technologies Used

- **C# (.NET 10.0)**: Primary programming language
- **ML.NET 5.0.0**: Microsoft's machine learning framework
- **ML.NET FastTree 5.0.0**: Gradient boosting implementation

## 📚 Dependencies

- `Microsoft.ML` (5.0.0): Core ML.NET library
- `Microsoft.ML.FastTree` (5.0.0): FastTree algorithm implementation

## 🔄 Extending the Application

To improve the model, you could:
1. Add the categorical feature `ocean_proximity` using one-hot encoding
2. Implement feature engineering (e.g., rooms per household ratio)
3. Try different algorithms (LightGBM, SDCA, etc.)
4. Perform hyperparameter tuning
5. Add cross-validation for more robust evaluation
6. Implement a web API for serving predictions

## 📝 License

[Add your license information here]

## 👥 Contributing

[Add contribution guidelines here]

## 📧 Contact

[Add contact information here]