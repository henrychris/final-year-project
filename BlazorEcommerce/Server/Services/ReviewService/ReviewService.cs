using Shared;

namespace BlazorEcommerce.Server.Services.ReviewService;

public class ReviewService : IReviewService
{
    private readonly DataContext _context;

    public ReviewService(DataContext context)
    {
        _context = context;
    }
    //public async Task<ServiceResponse<Review>> CheckIfUserPurchasedProduct(Review review)
    //{
    //    // Basically check user order history for this product.
    //    // reuse the product search algorithm
    //    throw new NotImplementedException();
    //}

    public async Task<ServiceResponse<Review>> CreateReview(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return new ServiceResponse<Review> { Data = review };
    }

    public async Task<ServiceResponse<bool>> DeleteReview(int reviewId)
    {
        var dbProduct = await _context.Reviews.FindAsync(reviewId);
        if (dbProduct == null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Data = false,
                Message = "Review not found."
            };
        }

        dbProduct.Deleted = true;

        await _context.SaveChangesAsync();
        return new ServiceResponse<bool> { Data = true };
    }

    public async Task<ServiceResponse<List<Review>>> GetReviewsForAProductAsync(int productId)
    {
        var response = new ServiceResponse<List<Review>>
        {
            Data = await _context.Reviews
                .Where(p => p.OnProductId == productId && (!p.Deleted && p.Visible))
                .ToListAsync()
        };
        // this should get the reviews belonging to a certain product
        return response;
    }
}