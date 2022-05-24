namespace BlazorEcommerce.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<User>> GetById(int id);
        Task<List<User>> GetAllUsers();
    }
}
