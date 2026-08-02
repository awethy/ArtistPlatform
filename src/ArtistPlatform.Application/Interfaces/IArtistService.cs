using ArtistPlatform.Application.DTOs.ArtistDTOs;
using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Application.Interfaces
{
    public interface IArtistService
    {
        Task<List<ArtistResponse>> GetAllAsync();
        Task<ArtistResponse> GetArtistByIdAsync(Guid id);
        Task<ArtistResponse> CreateArtistAsync(CreateArtistRequest artist);
        Task<ArtistResponse> UpdateArtistAsync(Guid id, UpdateArtistRequest artist);
        Task DeleteArtistAsync(Guid id);
    }
}
