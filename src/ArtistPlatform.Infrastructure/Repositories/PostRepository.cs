using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;
using ArtistPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ArtistPlatform.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalCountAsync(string? searchTerm)
        {
            var query = _context.Posts.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Title.Contains(searchTerm));
            }

            return await query.CountAsync();
        }

        public async Task<List<Post>> GetPagedAsync(int page, int pageSize, string? searchTerm, string? sortBy, bool descending)
        {
            var query = _context.Posts.AsNoTracking();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Title.Contains(searchTerm));
            }

            query = sortBy?.ToLower() switch
            {
                "title" => descending ? query.OrderByDescending(p => p.Title) : query.OrderBy(p => p.Title),
                "createdat" => descending ? query.OrderByDescending(p => p.CreatedAt) : query.OrderBy(p => p.CreatedAt),
                _ => query.OrderBy(p => p.CreatedAt)
            };

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await _context.Posts.AnyAsync(p => p.Title == title);
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPostsByArtistIdAsync(Guid id)
        {
            return await _context.Posts.Where(p => p.ArtistId == id).ToListAsync();
        }

        public async Task UpdateAsync(Post post)
        {
                _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
