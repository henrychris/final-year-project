namespace BlazorEcommerce.Server.Services.LikesService
{
    public interface ILikesService
    {
        // TODO just get the like count man
        Task<ReviewLikes> GetLike(int userId, int reviewId);

        Task<int> GetLikesCountForAReview(int reviewId);
    }
}
