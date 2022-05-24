using Shared;

namespace BlazorEcommerce.Server.Services.ReviewService;

public interface IReviewService
{
    // Add parameter to get reviews to limit the number fetched.
    Task<ServiceResponse<List<Review>>> GetReviewsForAProductAsync(int productId);
    Task<ServiceResponse<Review>> CreateReview(Review review);
    Task<ServiceResponse<Review>> CheckIfUserPurchasedProduct(Review review);
    Task<ServiceResponse<bool>> DeleteReview(int reviewId);
}