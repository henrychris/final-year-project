using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class UserInterest
    {
        public int Id { get; set; } 
        public bool Books { get; set; } 
        public bool Movies { get; set; } 
        public bool VideoGames { get; set; } 
        public bool Sports { get; set; }  
        public bool Clothing { get; set; } = false;
        public bool Default { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
