using ArtistPlatform.Application.DTOs.TrackDTOs;
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

        public async Task<TrackResponse> CreateTrackAsync(CreateTrackRequest trackRequest)
        {
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
            var track = await _trackRepository.GetByIdAsync(id);
            if (track == null)
            {
                return null;
            }
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
            var tracks = await _trackRepository.GetTracksByAlbumIdAsync(albumId);
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
            var tracks = await _trackRepository.GetTracksByArtistIdAsync(artistId);
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
            var track = await _trackRepository.GetByIdAsync(id);
            if (track == null)
            {
                return null;
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
