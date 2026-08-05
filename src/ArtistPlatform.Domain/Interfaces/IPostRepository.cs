using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetPagedAsync(int page, int pageSize, string? searchTerm, string? sortBy, bool descending);
        Task<int> GetTotalCountAsync(string? searchTerm);

        Task<bool> ExistsByTitleAsync(string title);
        Task<Post> GetByIdAsync(Guid id);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetPostsByArtistIdAsync(Guid id);
        Task AddAsync(Post post);
        Task UpdateAsync(Post post);
        Task DeleteAsync(Guid id);
    }
}
