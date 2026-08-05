using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Domain.Interfaces
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetPagedAsync(int page, int pageSize, string? searchTerm, string? sortBy, bool descending);
        Task<int> GetTotalCountAsync(string? searchTerm);

        Task<bool> ExistsByTitleAsync(string title);
        public Task<IEnumerable<Album>> GetAllAlbumsAsync();
        public Task<Album?> GetAlbumByIdAsync(Guid id);
        public Task<IEnumerable<Album?>> GetAlbumsByArtistIdAsync(Guid artistId);
        public Task AddAlbumAsync(Album album);
        public Task UpdateAlbumAsync(Album album);
        public Task DeleteAlbumAsync(Guid id);
    }
}
