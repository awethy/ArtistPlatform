using ArtistPlatform.Application.DTOs.AlbumDTOs;
using ArtistPlatform.Application.Exceptions;
using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;

namespace ArtistPlatform.Application.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<AlbumResponse> AddAlbumAsync(CreateAlbumRequest request)
        {
            if (await _albumRepository.ExistsByTitleAsync(request.Title))
            {
                throw new ConflictException($"An album with the title '{request.Title}' already exists.");
            }

            var album = new Album(
                request.Title,
                request.CoverUrl,
                request.ReleaseDate,
                request.ArtistId);

            await _albumRepository.AddAlbumAsync(album);

            return new AlbumResponse
            {
                Id = album.Id,
                Title = album.Title,
                CoverUrl = album.CoverUrl,
                ReleaseDate = album.ReleaseDate,
                ArtistId = album.ArtistId
            };
        }

        public async Task DeleteAlbumAsync(Guid id)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id)
                ?? throw new NotFoundExceptions("Album", id);
            await _albumRepository.DeleteAlbumAsync(id);
        }

        public async Task<AlbumResponse?> GetAlbumByIdAsync(Guid id)
        {
            var albums = await _albumRepository.GetAlbumByIdAsync(id)
                ?? throw new NotFoundExceptions("Album", id);
            return albums == null ? null : new AlbumResponse
            {
                Id = albums.Id,
                Title = albums.Title,
                CoverUrl = albums.CoverUrl,
                ReleaseDate = albums.ReleaseDate,
                ArtistId = albums.ArtistId
            };
        }

        public async Task<IEnumerable<AlbumResponse?>> GetAlbumsByArtistIdAsync(Guid artistId)
        {
            var albums = await _albumRepository.GetAlbumsByArtistIdAsync(artistId)
                ?? throw new NotFoundExceptions("Artist", artistId);
            return albums.Select(album => new AlbumResponse
            {
                Id = album.Id,
                Title = album.Title,
                CoverUrl = album.CoverUrl,
                ReleaseDate = album.ReleaseDate,
                ArtistId = album.ArtistId
            }).ToList();
        }

        public async Task<IEnumerable<AlbumResponse>> GetAllAlbumsAsync()
        {
            var albums = await _albumRepository.GetAllAlbumsAsync();
            return albums.Select(album => new AlbumResponse
            {
                Id = album.Id,
                Title = album.Title,
                CoverUrl = album.CoverUrl,
                ReleaseDate = album.ReleaseDate,
                ArtistId = album.ArtistId
            }).ToList();
        }

        public async Task<AlbumResponse> UpdateAlbumAsync(Guid id, UpdateAlbumRequest request)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id)
                ?? throw new NotFoundExceptions("Album", id);

            if (album.Title != request.Title && await _albumRepository.ExistsByTitleAsync(request.Title))
            {
                throw new ConflictException($"An album with the title '{request.Title}' already exists.");
            }

            album.Update(request.Title, request.CoverUrl, request.ReleaseDate);

            await _albumRepository.UpdateAlbumAsync(album);

            return new AlbumResponse
            {
                Id = album.Id,
                Title = album.Title,
                CoverUrl = album.CoverUrl,
                ReleaseDate = album.ReleaseDate,
                ArtistId = album.ArtistId
            };
        }
    }
}
