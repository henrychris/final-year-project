using Shared;

namespace BlazorEcommerce.Client.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly HttpClient _http;

        public ReviewService(HttpClient http)
        {
            _http = http;
        }

        public List<Review> Reviews { get; set; } = new List<Review>();
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string Message { get; set; } = "Loading reviews...";
        public async Task<ServiceResponse<Review>> CreateReview(Review review)
        {
            var result = await _http.PostAsJsonAsync("api/review", review);
            var newReview = (await result.Content.ReadFromJsonAsync<ServiceResponse<Review>>());
            return newReview;
        }

        public async Task DeleteReview(Review review)
        {
            await _http.DeleteAsync($"api/review/{review.Id}");
        }

        public async Task<List<Review>> GetReviewsForAProduct(int productId)
        {
            // confusion is plenty.
            // step back and restart.
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Review>>>($"api/review/{productId}");

            if (result != null && result.Data != null)
                Reviews = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Reviews.Count == 0)
                Message = "No reviews found";

            return Reviews;
        }

    }
}
