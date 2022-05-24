using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace BlazorEcommerce.Shared
{
    public class User
    {
        public virtual ICollection<ChatMessage> ChatMessagesFromUsers { get; set; }
        public virtual ICollection<Review> UserReviews { get; set; }
        public virtual ICollection<ChatMessage> ChatMessagesToUsers { get; set; }

        public User()
        {
            ChatMessagesFromUsers = new HashSet<ChatMessage>();
            ChatMessagesToUsers = new HashSet<ChatMessage>();
            UserReviews = new HashSet<Review>();
        }

        // add list of order history and foreign key.
        public Address Address { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;

        public int Id { get; set; }
        public string Name { get; set; } // add migration
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "Customer";
    }
}
