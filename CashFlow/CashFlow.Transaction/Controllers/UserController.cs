using CashFlow.Transaction.Application.DTOs;
using CashFlow.Transaction.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Transaction.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(CreateUserDto createUser)
        {
            if (string.IsNullOrWhiteSpace(createUser.Username) || string.IsNullOrWhiteSpace(createUser.Password))
            {
                return BadRequest("Username and password are required.");
            }
            var existingUser = await _userService.GetUserByUsername(createUser.Username);
            if (existingUser != null)
            {
                return Conflict("Username already exists.");
            }
            var result = await _userService.CreateUser(createUser);
            if (result)
            {
                return Ok("User created successfully.");
            }
            return BadRequest("Failed to create user.");
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDto loginUser)
        {
            var result = await _userService.LoginUser(loginUser);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Invalid username or password.");
        }
    }
}
