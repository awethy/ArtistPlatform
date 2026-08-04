using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.DTOs.AlbumDTOs;

namespace ArtistPlatform.Application.Interfaces
{
    public interface IAlbumService
    {
        Task<PagedResult<AlbumResponse>> GetPagedAlbumsAsync(PaginationRequest request);

        public Task<IEnumerable<AlbumResponse>> GetAllAlbumsAsync();
        public Task<AlbumResponse?> GetAlbumByIdAsync(Guid id);
        public Task<IEnumerable<AlbumResponse?>> GetAlbumsByArtistIdAsync(Guid artistId);
        public Task<AlbumResponse> AddAlbumAsync(CreateAlbumRequest request);
        public Task<AlbumResponse> UpdateAlbumAsync(Guid id, UpdateAlbumRequest request);
        public Task DeleteAlbumAsync(Guid id);
    }
}
