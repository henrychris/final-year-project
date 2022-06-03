using Shared;

namespace BlazorEcommerce.Client.Services.ChatService
{
    public interface IChatService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<List<ChatMessage>> GetConversationAsync(int contactId);
        Task SaveMessageAsync(ChatMessage message);
        Task<User> GetUserDetailsAsync(int userId);
    }
}
