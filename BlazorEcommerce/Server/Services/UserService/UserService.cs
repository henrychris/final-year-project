﻿namespace BlazorEcommerce.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private List<Category> UserCategories { get; set; } = new List<Category>();

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
                Data = await _context.Users.FirstOrDefaultAsync(p => p.Id == userId)
            };

            return response;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<Category>> GetUserInterests(int id)
        {
            var result = await _context.UserInterests.FindAsync(id);
            ConvertClassToList(result);
            return UserCategories;

        }

        private void ConvertClassToList(UserInterest userInterests)
        {
            if (userInterests.Books)
            {
                UserCategories.Add(new Category
                {
                    Name = "Books",
                    Url = "books"
                });
            }

            if (userInterests.Clothing)
            {
                UserCategories.Add(new Category
                {
                    Name = "Clothing",
                    Url = "clothing"
                });
            }

            if (userInterests.VideoGames)
            {
                UserCategories.Add(new Category
                {
                    Name = "Video Games",
                    Url = "video-games"
                });
            }

            if (userInterests.Sports)
            {
                UserCategories.Add(new Category
                {
                    Name = "Sports",
                    Url = "sports"
                });
            }

            if (userInterests.Movies)
            {
                UserCategories.Add(new Category
                {
                    Name = "Movies",
                    Url = "movies"
                });
            }
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
