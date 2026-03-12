using Microsoft.AspNetCore.Mvc;
using UMS_API_With_JWT_EF_CodeFirstApproach.DTOs;
using UMS_API_With_JWT_EF_CodeFirstApproach.Services;

namespace UMS_API_With_JWT_EF_CodeFirstApproach.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _tokenService;
        private static List<(string user, string pass)> users = new()
        {
            ("admin","123"),
            ("aryan","123"),
            ("student","123"),
            ("hostel","123"),
            ("warden","123")
        };

        public AuthController(JwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = users.FirstOrDefault(x => x.user == request.Username && x.pass == request.Password);

            if (user.user == null)
                return Unauthorized();


            var token = _tokenService.GenerateToken(request.Username);

            return Ok(new UMS_API_With_JWT_EF_CodeFirstApproach.DTOs.LoginResponse { Token = token });
            

            
        }
    }
}
