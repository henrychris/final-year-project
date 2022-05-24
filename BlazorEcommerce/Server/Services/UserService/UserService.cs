namespace BlazorEcommerce.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<ServiceResponse<User>> GetUserAsync(int userId)
        {
            var response = new ServiceResponse<User>
            {
                Data =  await _context.Users.FirstOrDefaultAsync(p => p.Id == userId)
                // this returned null.
            };

            return response;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
