# Simple ML App

A simple machine learning application built with ML.NET that predicts median house values using California housing data. This project demonstrates a complete ML workflow including data loading, model training, evaluation, and prediction.

## Overview

This application uses the FastTree regression algorithm to predict median house values based on various housing features such as location (longitude, latitude), housing age, room counts, population, households, and median income.

## Features

- **Data Loading**: Loads housing data from CSV file
- **Model Training**: Trains a FastTree regression model with normalized features
- **Model Evaluation**: Evaluates model performance using RMSE and R² metrics
- **Model Persistence**: Saves trained model to disk for reuse
- **Predictions**: Makes predictions on new housing data samples

## Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later
- Windows, Linux, or macOS

## Project Structure

```
SimpleMlApp/
├── Program.cs              # Main application code
├── SimpleMlApp.csproj      # Project file with dependencies
├── data.csv                # Housing dataset
└── model.zip               # Trained model (generated after training)
```

## Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd SimpleMlApp
```

2. Restore NuGet packages:
```bash
dotnet restore
```

## Usage

### Build the project:
```bash
dotnet build
```

### Run the application:
```bash
dotnet run --project SimpleMlApp
```

The application will:
1. Load the housing data from `data.csv`
2. Split the data into training (80%) and testing (20%) sets
3. Train a FastTree regression model
4. Evaluate the model and display RMSE and R² metrics
5. Save the trained model to `model.zip`
6. Load the saved model and make a sample prediction

### Expected Output

```
RMSE: <root_mean_squared_error>
R^2: <r_squared_value>
Predicted Median House Value: <predicted_value>
```

## Model Details

### Features Used
- Longitude
- Latitude
- Housing Median Age
- Total Rooms
- Total Bedrooms
- Population
- Households
- Median Income

### Target Variable
- Median House Value

### Algorithm
- **FastTree**: A gradient boosting decision tree algorithm optimized for regression tasks

### Data Preprocessing
- Features are normalized using Min-Max normalization
- Data is split 80/20 for training and testing

## Dependencies

- **Microsoft.ML** (5.0.0): Core ML.NET library
- **Microsoft.ML.FastTree** (5.0.0): FastTree regression trainer

## Data Format

The `data.csv` file should contain the following columns:
- `longitude`: Geographic longitude
- `latitude`: Geographic latitude
- `housing_median_age`: Median age of houses
- `total_rooms`: Total number of rooms
- `total_bedrooms`: Total number of bedrooms
- `population`: Population count
- `households`: Number of households
- `median_income`: Median income
- `median_house_value`: Median house value (target)
- `ocean_proximity`: Proximity to ocean (categorical, currently not used in model)

## License

This project is provided as-is for educational purposes.
