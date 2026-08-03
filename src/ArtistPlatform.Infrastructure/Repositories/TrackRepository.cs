using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;
using ArtistPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ArtistPlatform.Infrastructure.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ApplicationDbContext _context;

        public TrackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string title, Guid albumId, Guid artistId)
        {
            return await _context.Tracks.AnyAsync(t => t.Title == title && t.AlbumId == albumId && t.ArtistId == artistId);
        }

        public async Task AddAsync(Track track)
        {
            await _context.Tracks.AddAsync(track);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var track = await _context.Tracks.FindAsync(id);
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Track>> GetAllTracksAsync()
        {
            return await _context.Tracks.ToListAsync();
        }

        public async Task<Track?> GetByIdAsync(Guid id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        public async Task<List<Track>> GetTracksByAlbumIdAsync(Guid albumId)
        {
            return await _context.Tracks.Where(t => t.AlbumId == albumId).ToListAsync();
        }

        public Task<List<Track>> GetTracksByArtistIdAsync(Guid artistId)
        {
            return _context.Tracks.Where(t => t.ArtistId == artistId).ToListAsync();
        }

        public async Task UpdateAsync(Track track)
        {
            _context.Tracks.Update(track);
            await _context.SaveChangesAsync();
        }
    }
}
