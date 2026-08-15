using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.DTOs.TrackDTOs;
using ArtistPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetPagedAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var request = new PaginationRequest { Page = page, PageSize = pageSize };
            return Ok(await _trackService.GetPagedTracksAsync(request));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var track = await _trackService.GetTrackByIdAsync(id);

            return Ok(track);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTrackRequest request)
        {
            var track = await _trackService.CreateTrackAsync(request);

            return Ok(track);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, UpdateTrackRequest request)
        {
            var track = await _trackService.UpdateTrackAsync(id, request);

            return Ok(track);
        }
    }
}
