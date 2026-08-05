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

        public async Task<List<Artist>> GetPagedAsync(int page, int pageSize, string? searchTerm, string? sortBy, bool descending)
        {
            var query = _context.Artists.AsNoTracking();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(a => a.Name.Contains(searchTerm));
            }

            query = sortBy?.ToLower() switch
            {
                "name" => descending ? query.OrderByDescending(a => a.Name) : query.OrderBy(a => a.Name),
                "createdAt" => descending ? query.OrderByDescending(a => a.CreatedAt) : query.OrderBy(a => a.CreatedAt),
                _ => query.OrderBy(a => a.CreatedAt)
            };

            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync(string? searchTerm)
        {
            var query = _context.Artists.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(a => a.Name.Contains(searchTerm));
            }

            return await query.CountAsync();
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
