using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtistPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController : Controller
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _trackService.GetAllTracksAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var request = new PaginationRequest { Page = page, PageSize = pageSize };
            return Ok(await _trackService.GetPagedTracksAsync(request));
        }
    }
}
