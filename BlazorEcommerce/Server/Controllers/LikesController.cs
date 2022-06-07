using System.Security.Claims;
using BlazorEcommerce.Server.Services.LikesService;
using BlazorEcommerce.Server.Services.ReviewService;
using BlazorEcommerce.Server.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikesService _likesService;
        private readonly IUserService _userService;

        public LikesController(ILikesService likesService, IUserService userService, IReviewService reviewService)
        {
            _likesService = likesService;
            _userService = userService;
        }

        [HttpGet("likecount/{reviewId}")]
        public async Task<ActionResult<int>> GetLikeCountForAReview(int reviewId)
        {
            var result = await _likesService.GetLikesCountForAReview(reviewId);
            return Ok(result);
        }

        [HttpPost("likereview")]
        public async Task<ActionResult> AddLike(ReviewLikesDto likesDto)
        {
            var reviewMadeByUserId = likesDto.ReviewMadeByUserId;
            var reviewId = likesDto.ReviewId;
            var loggedInUserId = likesDto.LoggedInUserId;

            var loggedInUserResponse = await _userService.GetUserAsync(loggedInUserId);
            var loggedInUser = loggedInUserResponse.Data;

            // get the user that made the review
            var userResponse = await _userService.GetUserAsync(reviewMadeByUserId);
            var reviewMadeByUser = userResponse.Data;

            if (reviewMadeByUser == null) return NotFound();

            if (reviewMadeByUser.Id == loggedInUserId)
            {
                return BadRequest("You can not like your review.");
            }

            var reviewLike = await _likesService.GetLike(loggedInUserId, reviewId);

            if (reviewLike != null)
            {
                return BadRequest("You already liked this review.");
            };

            reviewLike = new ReviewLikes
            {
                LikedByUserId = loggedInUserId,
                LikedReviewId = reviewId
            };

            loggedInUser.UserReviewLikes.Add(reviewLike);

            if (await _userService.SaveAllChangesAsync()) return Ok();

            return BadRequest("Failed to like user.");

        }
    }
}
