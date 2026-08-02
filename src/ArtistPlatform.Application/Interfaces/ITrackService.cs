using ArtistPlatform.Application.DTOs.TrackDTOs;

namespace ArtistPlatform.Application.Interfaces
{
    public interface ITrackService
    {
        Task<List<TrackResponse>> GetAllTracksAsync();
        Task<List<TrackResponse>> GetTracksByAlbumIdAsync(Guid albumId);
        Task<List<TrackResponse>> GetTracksByArtistIdAsync(Guid artistId);
        Task<TrackResponse?> GetTrackByIdAsync(Guid id);
        Task<TrackResponse> CreateTrackAsync(CreateTrackRequest trackRequest);
        Task<TrackResponse?> UpdateTrackAsync(Guid id, UpdateTrackRequest trackRequest);
        Task DeleteTrackAsync(Guid id);
    }
}
