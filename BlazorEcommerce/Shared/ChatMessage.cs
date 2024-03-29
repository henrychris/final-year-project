using BlazorEcommerce.Shared;

namespace Shared
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual User FromUser { get; set; }
        public virtual User ToUser { get; set; }
    }
}