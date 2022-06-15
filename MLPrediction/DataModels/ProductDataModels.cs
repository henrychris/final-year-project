using Microsoft.ML.Data;

namespace MLPrediction.DataModels
{
    public class ProductDataModel
    {
        [LoadColumn(0)]
        public float userId;
        [LoadColumn(1)]
        public float productId;
        [LoadColumn(2)]
        public float Label;
    }
}
