using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlazorEcommerce.Shared;

namespace Shared
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public int MadeByUserId { get; set; }
        [Required]
        public int OnProductId { get; set; }
        [Required]
        public string ReviewText { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public virtual User MadeBy { get; set; }
        public virtual Product OnProduct { get; set; }

        public ICollection<ReviewLikes> LikedByUsers { get; set; }
        // might need to update this later on.
    }
}