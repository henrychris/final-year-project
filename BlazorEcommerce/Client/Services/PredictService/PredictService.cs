namespace BlazorEcommerce.Client.Services.PredictService
{
    public class PredictService : IPredictService
    {
        private readonly HttpClient _http;
        public PredictService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> GetProductRecommendation(ProductDataModel input)
        {
            var result = await _http.PostAsJsonAsync("api/predict", input);
            return await result.Content.ReadFromJsonAsync<bool>();
        }
    }
}
