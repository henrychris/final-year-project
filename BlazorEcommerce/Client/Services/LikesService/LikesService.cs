namespace BlazorEcommerce.Client.Services.LikesService
{
    public class LikesService : ILikesService
    {
        private readonly HttpClient _http;

        public LikesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<int> GetLikeCountForAReview(int reviewId)
        {
            var result = await _http.GetFromJsonAsync<int>($"api/likes/likecount/{reviewId}");
            return result;
        }

        public async Task AddLike(int reviewId, int reviewMadeByUserId, int loggedInUserId)
        {
            var reviewDto = new ReviewLikesDto
            {
                ReviewId = reviewId,
                ReviewMadeByUserId = reviewMadeByUserId,
                LoggedInUserId = loggedInUserId
            };

            await _http.PostAsJsonAsync($"api/likes/likereview", reviewDto);
        }
    }
}
