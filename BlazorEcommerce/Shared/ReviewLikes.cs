using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace BlazorEcommerce.Shared
{
    public class ReviewLikes
    {
        // primary key => userId, reviewId
        public User LikedByUser { get; set; }
        public int LikedByUserId { get; set; }

        public Review LikedReview { get; set; }
        public int LikedReviewId { get; set; }
    }
}
