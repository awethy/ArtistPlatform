using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.DTOs.TrackDTOs;
using ArtistPlatform.Application.Exceptions;
using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;

namespace ArtistPlatform.Application.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackService(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public async Task<PagedResult<TrackResponse>> GetPagedTracksAsync(PaginationRequest request)
        {
            var totalCount = await _trackRepository.GetTotalCountAsync(request.SearchTerm);
            var tracks = await _trackRepository.GetPagedAsync(request.Page, request.PageSize, request.SearchTerm, request.SortBy, request.Descending);
            var trackResponses = tracks.Select(track => new TrackResponse
            {
                Id = track.Id,
                Title = track.Title,
                Duration = track.Duration,
                AudioUrl = track.AudioUrl,
                AlbumId = track.AlbumId,
                ArtistId = track.ArtistId
            }).ToList();

            return new PagedResult<TrackResponse>
            {
                Items = trackResponses,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize 
            };
        }

        public async Task<TrackResponse> CreateTrackAsync(CreateTrackRequest trackRequest)
        {
            if (await _trackRepository.ExistsAsync(trackRequest.Title, trackRequest.AlbumId, trackRequest.ArtistId))
            {
                throw new ConflictException("A track with the same title already exists for this album and artist.");
            }

            var track = new Track(
                trackRequest.Title, 
                trackRequest.Duration, 
                trackRequest.AudioUrl, 
                trackRequest.AlbumId, 
                trackRequest.ArtistId);

            await _trackRepository.AddAsync(track);

            return new TrackResponse
            {
                Id = track.Id,
                Title = track.Title,
                Duration = track.Duration,
                AudioUrl = track.AudioUrl,
                AlbumId = track.AlbumId,
                ArtistId = track.ArtistId
            };
        }

        public async Task DeleteTrackAsync(Guid id)
        {
            var track = await _trackRepository.GetByIdAsync(id)
                ?? throw new NotFoundExceptions("Track", id);
            await _trackRepository.DeleteAsync(id);
        }

        public async Task<List<TrackResponse>> GetAllTracksAsync()
        {
            var tracks = await _trackRepository.GetAllTracksAsync();
            return tracks.Select(track => new TrackResponse
            {
                Id = track.Id,
                Title = track.Title,
                Duration = track.Duration,
                AudioUrl = track.AudioUrl,
                AlbumId = track.AlbumId,
                ArtistId = track.ArtistId
            }).ToList();
        }

        public async Task<TrackResponse?> GetTrackByIdAsync(Guid id)
        {
            var track = await _trackRepository.GetByIdAsync(id)
                ?? throw new NotFoundExceptions("Track", id);

            return new TrackResponse
            {
                Id = track.Id,
                Title = track.Title,
                Duration = track.Duration,
                AudioUrl = track.AudioUrl,
                AlbumId = track.AlbumId,
                ArtistId = track.ArtistId
            };
        }

        public async Task<List<TrackResponse>> GetTracksByAlbumIdAsync(Guid albumId)
        {
            var tracks = await _trackRepository.GetTracksByAlbumIdAsync(albumId)
                ?? throw new NotFoundExceptions("Album", albumId);
            return tracks.Select(track => new TrackResponse
            {
                Id = track.Id,
                Title = track.Title,
                Duration = track.Duration,
                AudioUrl = track.AudioUrl,
                AlbumId = track.AlbumId,
                ArtistId = track.ArtistId
            }).ToList();
        }

        public async Task<List<TrackResponse>> GetTracksByArtistIdAsync(Guid artistId)
        {
            var tracks = await _trackRepository.GetTracksByArtistIdAsync(artistId)
                ?? throw new NotFoundExceptions("Artist", artistId);
            return tracks.Select(track => new TrackResponse
            {
                Id = track.Id,
                Title = track.Title,
                Duration = track.Duration,
                AudioUrl = track.AudioUrl,
                AlbumId = track.AlbumId,
                ArtistId = track.ArtistId
            }).ToList();
        }

        public async Task<TrackResponse?> UpdateTrackAsync(Guid id, UpdateTrackRequest trackRequest)
        {
            var track = await _trackRepository.GetByIdAsync(id)
                ?? throw new NotFoundExceptions("Track", id);

            if (track.Title != trackRequest.Title && await _trackRepository.ExistsAsync(trackRequest.Title, track.AlbumId, track.ArtistId))
            {
                throw new ConflictException("A track with the same title already exists for this album and artist.");
            }

            track.Update(trackRequest.Title, trackRequest.Duration, trackRequest.AudioUrl);

            await _trackRepository.UpdateAsync(track);

            return new TrackResponse
            {
                Id = track.Id,
                Title = track.Title,
                Duration = track.Duration,
                AudioUrl = track.AudioUrl,
                AlbumId = track.AlbumId,
                ArtistId = track.ArtistId
            };
        }
    }
}
