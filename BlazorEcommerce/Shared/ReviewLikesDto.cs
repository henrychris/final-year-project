using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class ReviewLikesDto
    {
        public int ReviewId { get; set; }
        public int ReviewMadeByUserId { get; set; }
        public int LoggedInUserId { get; set; }
    }
}
