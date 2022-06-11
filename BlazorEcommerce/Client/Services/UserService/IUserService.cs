namespace BlazorEcommerce.Client.Services.UserService
{
    public interface IUserService
    {
        List<Category> UserCategories { get; set; }
        Task GetUserInterests(int id);
        Task<ServiceResponse<User>> GetById(int id);
        Task<List<User>> GetAllUsers();
        Task<bool> CheckIfUserAcceptsMessages(int userId);
    }
}
