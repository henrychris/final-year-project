using Shared;

namespace BlazorEcommerce.Client.Services.ChatService
{
    public class ChatService : IChatService
    {
        private readonly HttpClient _httpClient;

        public ChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ChatMessage>> GetConversationAsync(int contactId)
        {
            return await _httpClient.GetFromJsonAsync<List<ChatMessage>>($"api/Chat/{contactId}");
        }
        public async Task<User> GetUserDetailsAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<User>($"api/Chat/users/{userId}");
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            var data = await _httpClient.GetFromJsonAsync<List<User>>("api/Chat/allusers");
            return data;
        }
        public async Task SaveMessageAsync(ChatMessage message)
        {
            await _httpClient.PostAsJsonAsync("api/Chat", message);
        }
    }
}
