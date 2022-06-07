using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Services.LikesService
{
    public class LikesService : ILikesService
    {
        private readonly DataContext _context;

        public LikesService(DataContext context)
        {
            _context = context;
        }
        public async Task<ReviewLikes> GetLike(int userId, int reviewId)
        {
            return await _context.ReviewLikes.FindAsync(userId, reviewId);
        }

        public async Task<int> GetLikesCountForAReview(int reviewId)
        {
            var reviewCount = await _context.ReviewLikes.CountAsync(i => i.LikedReviewId == reviewId);
            return reviewCount;
        }
    }
}
