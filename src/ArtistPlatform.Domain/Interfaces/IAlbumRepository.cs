using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Domain.Interfaces
{
    public interface IAlbumRepository
    {
        public Task<IEnumerable<Album>> GetAllAlbumsAsync();
        public Task<Album?> GetAlbumByIdAsync(Guid id);
        public Task<IEnumerable<Album?>> GetAlbumsByArtistIdAsync(Guid artistId);
        public Task AddAlbumAsync(Album album);
        public Task UpdateAlbumAsync(Album album);
        public Task DeleteAlbumAsync(Guid id);
    }
}
