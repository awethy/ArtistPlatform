using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.DTOs.PostDTOs;
using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetPagedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var request = new PaginationRequest { Page = page, PageSize = pageSize };
            return Ok(await _postService.GetPagedPostsAsync(request));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var post = await _postService.GetPostByIdAsync(id);

            return Ok(post);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Create(CreatePostRequest request)
        {
            var post = await _postService.CreatePostAsync(request);

            return Ok(post);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Update(Guid id, UpdatePostRequest request)
        {
            var post = await _postService.UpdatePostAsync(id, request);

            return Ok(post);
        }
    }
}
