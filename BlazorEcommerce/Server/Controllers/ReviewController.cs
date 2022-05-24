using BlazorEcommerce.Server.Services.ReviewService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Review>>> CreateReview(Review review)
        {
            var result = await _reviewService.CreateReview(review);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        // only let a user delete HIS review
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteReview(int reviewId)
        {
            var result = await _reviewService.DeleteReview(reviewId);
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<List<Review>>>> GetReviewsForAProduct(int productId)
        {
            var result = await _reviewService.GetReviewsForAProductAsync(productId);
            return Ok(result);
        }
    }
}
