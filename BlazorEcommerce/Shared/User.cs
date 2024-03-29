﻿using System.ComponentModel.DataAnnotations.Schema;
using Shared;

namespace BlazorEcommerce.Shared
{
    public class User
    {
        public virtual ICollection<ChatMessage> ChatMessagesFromUsers { get; set; }
        public virtual ICollection<Review> UserReviews { get; set; }
        public ICollection<ReviewLikes> UserReviewLikes { get; set; }
        public virtual ICollection<ChatMessage> ChatMessagesToUsers { get; set; }

        public User()
        {
            ChatMessagesFromUsers = new HashSet<ChatMessage>();
            ChatMessagesToUsers = new HashSet<ChatMessage>();
            UserReviews = new HashSet<Review>();
            UserReviewLikes = new HashSet<ReviewLikes>();
        }

        // add list of order history and foreign key.
        public Address Address { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } // add migration
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; } = "Customer";
        public bool AcceptsMessages { get; set; }
        public UserInterest UserInterests { get; set; }
    }
}
