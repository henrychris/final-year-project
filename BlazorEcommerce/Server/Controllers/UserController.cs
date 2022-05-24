using BlazorEcommerce.Server.Services.ReviewService;
using BlazorEcommerce.Server.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

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
    }
}
