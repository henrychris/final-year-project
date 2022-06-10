using Microsoft.AspNetCore.SignalR;
using Shared;

namespace BlazorEcommerce.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageAsync(string user, ChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}