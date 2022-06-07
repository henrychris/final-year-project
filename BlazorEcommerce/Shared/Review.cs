using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorEcommerce.Shared;

namespace Shared
{
    public class Review
    {
        public int Id { get; set; }
        public int MadeByUserId { get; set; }
        public int OnProductId { get; set; }
        public string ReviewText { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public virtual User MadeBy { get; set; }
        public virtual Product OnProduct { get; set; }

        public ICollection<ReviewLikes> LikedByUsers { get; set; }
        // might need to update this later on.
    }
}