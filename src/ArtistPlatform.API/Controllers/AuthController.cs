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

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var response = await _authService.Register(request);

            return Ok(response);
        }
    }
}
