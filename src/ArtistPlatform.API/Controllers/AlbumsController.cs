using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtistPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbumsAsync()
        {
            return Ok(await _albumService.GetAllAlbumsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAlbumsAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var request = new PaginationRequest { Page = page, PageSize = pageSize };
            return Ok(await _albumService.GetPagedAlbumsAsync(request));
        }
    }
}
