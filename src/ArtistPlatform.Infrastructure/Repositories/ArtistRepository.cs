using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;
using ArtistPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ArtistPlatform.Infrastructure.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDbContext _context;

        public ArtistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Artists.AnyAsync(a => a.Name == name);
        }

        public async Task AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var artist = await _context.Artists.FindAsync(id);
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist?> GetByIdAsync(Guid id)
        {
            return await _context.Artists.FindAsync(id);
        }

        public async Task UpdateAsync(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }
    }
}
