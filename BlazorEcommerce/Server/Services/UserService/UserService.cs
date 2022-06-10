namespace BlazorEcommerce.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfUserAcceptsMessages(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.Id == userId);
            return user.AcceptsMessages;
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

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
