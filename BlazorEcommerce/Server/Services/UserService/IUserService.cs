namespace BlazorEcommerce.Server.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> GetUserAsync(int userId);
        Task<List<User>> GetUsers();
    }
}
