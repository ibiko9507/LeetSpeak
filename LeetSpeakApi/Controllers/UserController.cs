using LeetSpeak.Abstractions;
using LeetSpeak.Business.Services;
using LeetSpeak.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeetSpeak.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        #region Properties
        private readonly IUserService _userService;
        #endregion

        public UserController(
            IUserService userService
            )
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserRequest loginUserRequest)
        {
            var user = await _userService.Login(loginUserRequest);
            return Ok(user);
        }
    }
}
