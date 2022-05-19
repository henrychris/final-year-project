using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public class Review
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string ReviewText { get; set; }
        public DateTime DateCreated { get; set; }

        // might need to update this later on.
    }
}