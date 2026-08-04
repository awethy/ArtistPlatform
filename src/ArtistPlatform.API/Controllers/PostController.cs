using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtistPlatform.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _postService.GetAllPostsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var request = new PaginationRequest { Page = page, PageSize = pageSize };
            return Ok(await _postService.GetPagedPostsAsync(request));
        }
    }
}
