using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtistPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistsController : Controller
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            // Implementation for getting all artists
            return Ok(await _artistService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            // Implementation for getting paged artists
            var request = new PaginationRequest { Page = page, PageSize = pageSize };
            return Ok(await _artistService.GetPagedAsync(request));
        }
    }
}
