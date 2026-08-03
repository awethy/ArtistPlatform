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

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(Guid id)
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
