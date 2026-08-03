using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;
using ArtistPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ArtistPlatform.Infrastructure.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationDbContext _context;
        public AlbumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await _context.Albums.AnyAsync(a => a.Title == title);
        }

        public async Task AddAlbumAsync(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlbumAsync(Guid id)
        {
            var album = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }

        public async Task<Album?> GetAlbumByIdAsync(Guid id)
        {
            return await _context.Albums.FindAsync(id);
        }

        public async Task<IEnumerable<Album?>> GetAlbumsByArtistIdAsync(Guid artistId)
        {
            return await _context.Albums.Where(a => a.ArtistId == artistId).ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }
    }
}
