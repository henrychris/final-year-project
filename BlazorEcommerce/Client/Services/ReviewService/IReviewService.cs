using Shared;

namespace BlazorEcommerce.Client.Services.ReviewService;

public interface IReviewService
{
    int CurrentPage { get; set; }
    int PageCount { get; set; }
    string Message { get; set; }
    public List<Review> Reviews { get; set; }
    Task<ServiceResponse<Review>> CreateReview(Review review);
    Task DeleteReview(Review review);
    Task<List<Review>> GetReviewsForAProduct(int productId);
}