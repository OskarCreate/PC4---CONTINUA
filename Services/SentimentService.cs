using Microsoft.ML;
using System.IO;

namespace Prueba_ml.Services
{
    public class SentimentService
    {
        private readonly string _modelPath = "MLModels/sentiment_model.zip";
        private readonly MLContext _mlContext;
        private PredictionEngine<SentimentData, SentimentPrediction> _predEngine;

        public SentimentService()
        {
            _mlContext = new MLContext();

            if (!File.Exists(_modelPath))
                TrainModel();

            LoadModel();
        }

        private void TrainModel()
        {
            var data = _mlContext.Data.LoadFromTextFile<SentimentData>(
                "Data/sentiment-data.tsv", hasHeader: true);

            var pipeline = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

            var model = pipeline.Fit(data);

            _mlContext.Model.Save(model, data.Schema, _modelPath);
        }

        private void LoadModel()
        {
            var loadedModel = _mlContext.Model.Load(_modelPath, out _);
            _predEngine = _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(loadedModel);
        }

        public SentimentPrediction Predict(string text)
        {
            return _predEngine.Predict(new SentimentData { Text = text });
        }
    }
}