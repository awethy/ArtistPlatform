using ArtistPlatform.Application.Common.Pagination;
using ArtistPlatform.Application.DTOs.ArtistDTOs;
using ArtistPlatform.Application.Exceptions;
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

        public async Task<PagedResult<ArtistResponse>> GetPagedAsync(PaginationRequest request)
        {
            var totalCount = await _artistRepository.GetTotalCountAsync(request.SearchTerm);
            var artists = await _artistRepository.GetPagedAsync(request.Page, request.PageSize, request.SearchTerm, request.SortBy, request.Descending);
            var artistResponses = artists.Select(artist => new ArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
                CreatedAt = artist.CreatedAt
            }).ToList();

            return new PagedResult<ArtistResponse>
            {
                Items = artistResponses,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }

        public async Task<ArtistResponse> CreateArtistAsync(CreateArtistRequest request)
        {
            if (await _artistRepository.ExistsByNameAsync(request.Name))
            {
                throw new ConflictException($"Artist with name '{request.Name}' already exists.");
            }

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

        public async Task DeleteArtistAsync(Guid id)
        {
            var artist = await _artistRepository.GetByIdAsync(id)
                ?? throw new NotFoundExceptions("Artist", id);

            await _artistRepository.DeleteAsync(id);
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
            var artist = await _artistRepository.GetByIdAsync(id)
                ?? throw new NotFoundExceptions("Artist", id);
            return new ArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
                CreatedAt = artist.CreatedAt
            };
        }

        public async Task<ArtistResponse> UpdateArtistAsync(Guid id, UpdateArtistRequest request)
        {
            var artist = await _artistRepository.GetByIdAsync(id)
                ?? throw new NotFoundExceptions("Artist", id);

            if (artist.Name != request.Name && await _artistRepository.ExistsByNameAsync(request.Name))
            {
                throw new ConflictException($"Artist with name '{request.Name}' already exists.");
            }

            artist.Update(request.Name, request.Bio);

            await _artistRepository.UpdateAsync(artist);

            return new ArtistResponse
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
                CreatedAt = artist.CreatedAt
            };
        }
    }
}
