using ArtistPlatform.Domain.Entities;
using NpgsqlTypes;

namespace ArtistPlatform.Domain.Interfaces
{
    public interface ITrackRepository
    {
        Task<List<Track>> GetAllTracksAsync();
        Task<List<Track>> GetTracksByAlbumIdAsync(Guid albumId);
        Task<List<Track>> GetTracksByArtistIdAsync(Guid artistId);
        Task<Track> GetByIdAsync(Guid id);
        Task AddAsync(Track track);
        Task UpdateAsync(Track track);
        Task DeleteAsync(Guid id);
    }
}
