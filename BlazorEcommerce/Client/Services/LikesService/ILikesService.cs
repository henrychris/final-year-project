namespace BlazorEcommerce.Client.Services.LikesService
{
    public interface ILikesService
    {
        Task<int> GetLikeCountForAReview(int reviewId);
        Task AddLike(int reviewId, int reviewMadeByUserId, int loggedInUserId);
    }
}
