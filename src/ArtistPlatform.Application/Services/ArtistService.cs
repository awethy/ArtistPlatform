using ArtistPlatform.Application.DTOs.ArtistDTOs;
using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;

namespace ArtistPlatform.Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<ArtistResponse> CreateArtistAsync(CreateArtistRequest request)
        {
            var artist = new Artist(
                request.Name,
                request.Bio);

            await _artistRepository.AddAsync(artist);

            return new ArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
                CreatedAt = artist.CreatedAt
            };
        }

        public Task DeleteArtistAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ArtistResponse>> GetAllAsync()
        {
            var artists = await _artistRepository.GetAllAsync();
            return artists.Select(artist => new ArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
                CreatedAt = artist.CreatedAt
            }).ToList();
        }

        public async Task<ArtistResponse> GetArtistByIdAsync(Guid id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null)
            {
                throw new KeyNotFoundException($"Artist with id {id} not found.");
            }

            return new ArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
                CreatedAt = artist.CreatedAt
            };
        }

        public Task<ArtistResponse> UpdateArtistAsync(UpdateArtistRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
