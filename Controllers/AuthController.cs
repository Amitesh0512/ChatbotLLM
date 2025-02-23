using ChatbotLLM.Models;
using ChatbotLLM.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatbotLLM.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "admin", PasswordHash = "admin123" }
        };

        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthRequest request)
        {
            var user = users.FirstOrDefault(u => u.Username == request.Username && u.PasswordHash == request.Password);

            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            var token = _jwtService.GenerateToken(user.Username);
            return Ok(new { token });
        }
    }
}
