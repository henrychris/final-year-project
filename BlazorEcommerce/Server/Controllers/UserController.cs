using BlazorEcommerce.Server.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("find/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetUser(int userId)
        {
            var result = await _userService.GetUserAsync(userId);
            return Ok(result);
        }

        [HttpGet("allusers")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetAllUsers()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }

        [HttpGet("acceptsmessages/{userId}")]
        public async Task<ActionResult<bool>> CheckIfUserAcceptsMessages(int userId)
        {
            var result = await _userService.CheckIfUserAcceptsMessages(userId);
            return Ok(result);
        }

        [HttpGet("userInterests/{userId}")]
        public async Task<ActionResult<List<Category>>> GetUserInterests(int userId)
        {
            var result = await _userService.GetUserInterests(userId);
            return Ok(result);
        }
    }
}
