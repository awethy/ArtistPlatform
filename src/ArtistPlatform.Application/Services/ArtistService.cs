using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Application.Services
{
    public class ArtistService : IArtistService
    {
        public Task<List<Artist>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
