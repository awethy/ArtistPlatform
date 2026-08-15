using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.DTOs.ArtistDTOs;
using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetPagedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            // Implementation for getting paged artists
            var request = new PaginationRequest { Page = page, PageSize = pageSize };
            return Ok(await _artistService.GetPagedAsync(request));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _artistService.GetArtistByIdAsync(id));
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Create(CreateArtistRequest request)
        {
            var artist = await _artistService.CreateArtistAsync(request);

            return StatusCode(StatusCodes.Status201Created, artist);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Update(Guid id, UpdateArtistRequest request)
        {
            var artist = await _artistService.UpdateArtistAsync(id, request);

            return Ok(artist);
        }

        //[HttpDelete("{id:guid}")]
        //[Authorize(Roles = nameof(UserRole.Admin))]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    await _artistService.DeleteArtistAsync(id);

        //    return NoContent();
        //}
    }
}
