using Microsoft.ML;
using Microsoft.ML.Data;
using System.IO;

public class SentimentModel
{
    private readonly MLContext _mlContext;
    private readonly PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;

    public SentimentModel()
    {
        _mlContext = new MLContext();

        var dataPath = Path.Combine("Data", "sentiment-data.tsv");

        
        var dataView = _mlContext.Data.LoadFromTextFile<SentimentData>(
            path: dataPath,
            hasHeader: true,
            separatorChar: '\t');

       
        var pipeline = _mlContext.Transforms.Text.FeaturizeText(
                            outputColumnName: "Features",
                            inputColumnName: nameof(SentimentData.Text))
                        .Append(_mlContext.BinaryClassification.Trainers
                            .SdcaLogisticRegression(
                                labelColumnName: nameof(SentimentData.Label),
                                featureColumnName: "Features"));

        
        var model = pipeline.Fit(dataView);

        
        _predictionEngine = _mlContext.Model
            .CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
    }

    public SentimentPrediction Predict(string text)
    {
        return _predictionEngine.Predict(new SentimentData { Text = text });
    }
}
