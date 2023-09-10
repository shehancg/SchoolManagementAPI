using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Models;
using CoreWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAuthService _authService;

        public AuthController(IJwtService jwtService, IAuthService authService)
        {
            _jwtService = jwtService;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            // Authenticate user
            var user = _authService.Authenticate(model.Username, model.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");

            // Retrieve roles for the authenticated user (replace this with your actual logic)
            var roles = new List<string> { "UserRole1", "UserRole2" };

            // Generate JWT token with username and roles
            var token = _jwtService.GenerateJwtToken(user.Username, roles);

            return Ok(new { Token = token });
        }

    }
}
