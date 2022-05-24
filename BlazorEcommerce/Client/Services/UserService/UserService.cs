﻿namespace BlazorEcommerce.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<User>> GetById(int userId)
        {
            var result =  await _http.GetFromJsonAsync<ServiceResponse<User>>($"api/user/find/{userId}");
            return result;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await _http.GetFromJsonAsync<List<User>>($"api/user/allusers");
            return result;
        }

    }
}