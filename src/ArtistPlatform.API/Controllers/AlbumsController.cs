using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.DTOs.AlbumDTOs;
using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetPagedAlbumsAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var request = new PaginationRequest { Page = page, PageSize = pageSize };
            return Ok(await _albumService.GetPagedAlbumsAsync(request));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var album = await _albumService.GetAlbumByIdAsync(id);

            return Ok(album);
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Create(CreateAlbumRequest request)
        {
            var album = await _albumService.AddAlbumAsync(request);

            return Ok(album);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Update(Guid id, UpdateAlbumRequest request)
        {
            var album = await _albumService.UpdateAlbumAsync(id, request);

            return Ok(album);
        }
    }
}
