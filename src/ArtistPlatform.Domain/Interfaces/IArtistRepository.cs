using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Domain.Interfaces
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetPagedAsync(int page, int pageSize, string? searchTerm, string? sortBy, bool descending);
        Task<int> GetTotalCountAsync(string? searchTerm);

        Task<bool> ExistsByNameAsync(string name);
        Task<List<Artist>> GetAllAsync();
        Task<Artist?> GetByIdAsync(Guid id);
        Task AddAsync(Artist artist);
        Task UpdateAsync(Artist artist);
        Task DeleteAsync(Guid id);
    }
}
