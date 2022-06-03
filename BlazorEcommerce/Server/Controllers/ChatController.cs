using System.Security.Claims;
using BlazorEcommerce.Server.Services.ReviewService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly DataContext _context;

        public ChatController(DataContext context)
        {
            _context = context;

        }

        [HttpGet("allusers")]
        public async Task<List<User>> GetUsersAsync()
        {
            var userId = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault();
            var allUsers = await _context.Users.Where(user => user.Id.ToString() != userId).ToListAsync();
            return allUsers;
        }

        [HttpGet("users/{userId}")]
        public async Task<User> GetUserDetailsAsync(int userId)
        {
            var user = await _context.Users.Where(user => user.Id == userId).FirstOrDefaultAsync();
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> SaveMessageAsync(ChatMessage message)
        {
            //var userId = Convert.ToInt32(User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault());
            //message.FromUserId = userId;
            message.CreatedDate = DateTime.Now;
            message.ToUser = await _context.Users.Where(user => user.Id == message.ToUserId).FirstOrDefaultAsync();
            //message.FromUser = await _context.Users.Where(user => user.Id == message.FromUserId).FirstOrDefaultAsync();
            await _context.ChatMessages.AddAsync(message);
            return Ok(await _context.SaveChangesAsync());
        }

        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetConversationAsync(int contactId)
        {
            // contactId is the second person in the conversation, other than the logged in user.
            var userId = User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault();
            var userIdInt = Convert.ToInt32(userId);

            var messages = await _context.ChatMessages
                .Where(h => (h.FromUserId == contactId && h.ToUserId == userIdInt) || (h.FromUserId == userIdInt && h.ToUserId == contactId))
                .OrderBy(a => a.CreatedDate)
                .Include(a => a.FromUser)
                .Include(a => a.ToUser)
                .Select(x => new ChatMessage
                {
                    FromUserId = x.FromUserId,
                    Message = x.Message,
                    CreatedDate = x.CreatedDate,
                    Id = x.Id,
                    ToUserId = x.ToUserId,
                    ToUser = x.ToUser,
                    FromUser = x.FromUser
                }).ToListAsync();

            return Ok(messages);
        }
    }
}
