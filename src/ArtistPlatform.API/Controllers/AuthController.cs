using ArtistPlatform.Application.DTOs.AuthDTOs;
using ArtistPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtistPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _authService.Register(request);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _authService.Login(request);

            return Ok(response);
        }
    }
}
