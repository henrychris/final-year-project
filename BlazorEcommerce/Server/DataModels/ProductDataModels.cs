using Microsoft.ML.Data;

namespace BlazorEcommerce.Server.DataModels
{
    public class ProductDataModel
    {
        //[LoadColumn(0)]
        public float userId { get; set; }
        //[LoadColumn(1)]
        public float productId { get; set; }
        //[LoadColumn(2)]
        public float Label { get; set; }

        //{
        //    "userId":1,
        //    "productId":1,
        //    "Label":5
        //}
    }
}
