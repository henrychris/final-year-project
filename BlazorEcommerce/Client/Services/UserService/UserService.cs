namespace BlazorEcommerce.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        public List<Category> UserCategories { get; set; } = new List<Category>();

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<User>> GetById(int userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<User>>($"api/user/find/{userId}");
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _http.GetFromJsonAsync<List<User>>($"api/user/allusers");
            return result;
        }

        public async Task<bool> CheckIfUserAcceptsMessages(int userId)
        {
            var result = await _http.GetFromJsonAsync<bool>($"api/user/acceptsmessages/{userId}");
            return result;
        }

        public async Task GetUserInterests(int userId)
        {
            var result = await _http.GetFromJsonAsync<List<Category>>($"api/user/userInterests/{userId}");
            UserCategories = result;
        }
    }
}
