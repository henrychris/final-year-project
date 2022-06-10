using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Shared;

namespace BlazorEcommerce.Client.Shared
{
    public partial class Messages
    {
        [CascadingParameter] public HubConnection HubConnection { get; set; }

        public List<User> ChatUsers = new();
        private List<ChatMessage> _messages = new();
        public string ContactEmail { get; set; }
        [Parameter] public int ContactId { get; set; }
        public bool UserAcceptsMessages { get; set; }
        public string CurrentMessage { get; set; }
        public string CurrentUserEmail { get; set; }
        public int CurrentUserId { get; set; }
        ElementReference _chatElementReference;

        protected override async Task OnInitializedAsync()
        {
            if (HubConnection == null)
            {
                HubConnection = new HubConnectionBuilder()
                .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
                .Build();
            }

            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }

            HubConnection.On<string, ChatMessage>("ReceiveMessage", async (userName, message) =>
            {
                if ((ContactId == message.ToUserId && CurrentUserId == message.FromUserId) || (ContactId == message.FromUserId && CurrentUserId == message.ToUserId))
                {

                    if ((ContactId == message.ToUserId && CurrentUserId == message.FromUserId))
                    {
                        _messages.Add(new ChatMessage { Message = message.Message, CreatedDate = message.CreatedDate, FromUser = new User() { Email = CurrentUserEmail } });
                        await HubConnection.SendAsync("ChatNotificationAsync", $"New Message From {userName}", ContactId, CurrentUserId);
                    }
                    else if (ContactId == message.FromUserId && CurrentUserId == message.ToUserId)
                    {
                        _messages.Add(new ChatMessage { Message = message.Message, CreatedDate = message.CreatedDate, FromUser = new User() { Email = ContactEmail } });
                    }
                    StateHasChanged();
                }
            });

            await GetUsersAsync();

            await SetCurrentUserId();

            if (ContactId != 0)
            {
                await LoadUserChat(ContactId);
                await CheckIfUserAcceptsMessages(ContactId);
            }
        }

        private async Task GetUsersAsync()
        {
            ChatUsers = await ChatService.GetAllUsersAsync();
            await SetCurrentUserId();
            var user = await UserService.GetById(CurrentUserId);
            ChatUsers.Remove(user.Data);
        }

        private async Task SendAsync()
        {
            if (!string.IsNullOrEmpty(CurrentMessage) && !string.IsNullOrEmpty(ContactId.ToString()) && HubConnection is not null)
            {
                var chatHistory = new ChatMessage()
                {
                    FromUserId = CurrentUserId,
                    Message = CurrentMessage,
                    ToUserId = ContactId,
                    CreatedDate = DateTime.Now
                };
                await ChatService.SaveMessageAsync(chatHistory);
                chatHistory.FromUserId = CurrentUserId;
                await HubConnection.SendAsync("SendMessageAsync", CurrentUserEmail, chatHistory);
                CurrentMessage = string.Empty;
            }
        }

        private async Task SetCurrentUserId()
        {
            var state = await StateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            CurrentUserId = Convert.ToInt32(user.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault());
            // add method to get user email 
            CurrentUserEmail = user.Claims.Where(a => a.Type == ClaimTypes.Email).Select(a => a.Value).FirstOrDefault();
        }

        private async Task LoadUserChat(int userId)
        {
            var contact = await ChatService.GetUserDetailsAsync(userId);
            ContactId = contact.Id;
            ContactEmail = contact.Email;
            NavigationManager.NavigateTo($"messages/{ContactId}");
            _messages = new List<ChatMessage>();
            _messages = await ChatService.GetConversationAsync(ContactId);
        }

        private async Task NavigateToGivenId(int id)
        {
            await SetCurrentUserId();
            if (id == CurrentUserId)
            {
                NavigationManager.NavigateTo("");
                NavigationManager.NavigateTo("messages");
            }
            NavigationManager.NavigateTo("");
            NavigationManager.NavigateTo($"messages/{id}");
        }

        private async Task<bool> CheckIfUserAcceptsMessages(int userId)
        {
            return UserAcceptsMessages = await UserService.CheckIfUserAcceptsMessages(userId);
        }
    }
}