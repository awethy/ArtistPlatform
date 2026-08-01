
using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Application.Interfaces
{
    public interface IArtistService
    {
        Task<List<Artist>> GetAllAsync();
    }
}
