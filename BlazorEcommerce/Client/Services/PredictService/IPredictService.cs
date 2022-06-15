namespace BlazorEcommerce.Client.Services.PredictService
{
    public interface IPredictService
    {
        Task<bool> GetProductRecommendation(ProductDataModel input);
    }

    public class ProductDataModel
    {
        // label doesn't need to be passed
        public float UserId { get; set; }
        public float ProductId { get; set; }
        public float Label { get; set; }
    }
}
