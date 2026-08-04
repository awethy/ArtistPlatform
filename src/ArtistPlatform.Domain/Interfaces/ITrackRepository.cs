using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Domain.Interfaces
{
    public interface ITrackRepository
    {
        Task<List<Track>> GetPagedAsync(int page, int pageSize);
        Task<int> GetTotalCountAsync();

        Task<bool> ExistsAsync(string title, Guid albumId, Guid artistId);
        Task<List<Track>> GetAllTracksAsync();
        Task<List<Track>> GetTracksByAlbumIdAsync(Guid albumId);
        Task<List<Track>> GetTracksByArtistIdAsync(Guid artistId);
        Task<Track> GetByIdAsync(Guid id);
        Task AddAsync(Track track);
        Task UpdateAsync(Track track);
        Task DeleteAsync(Guid id);
    }
}
