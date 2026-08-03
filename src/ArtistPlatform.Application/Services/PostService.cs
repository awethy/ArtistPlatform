using ArtistPlatform.Application.DTOs.PostDTOs;
using ArtistPlatform.Application.Exceptions;
using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;

namespace ArtistPlatform.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostResponse> CreatePostAsync(CreatePostRequest request)
        {
            if (await _postRepository.ExistsByTitleAsync(request.Title))
            {
                throw new ConflictException("A post with the same title already exists for this artist.");
            }

            var post = new Post(
                request.Title,
                request.Content,
                request.ArtistId);

            await _postRepository.AddAsync(post);

            return new PostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                ArtistId = post.ArtistId
            };
        }

        public async Task DeletePostAsync(Guid postId)
        {
            var post = await _postRepository.GetByIdAsync(postId)
                ?? throw new NotFoundExceptions("Post", postId);
            await _postRepository.DeleteAsync(postId);
        }

        public async Task<IEnumerable<PostResponse>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Select(post => new PostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                ArtistId = post.ArtistId
            });
        }

        public async Task<PostResponse> GetPostByIdAsync(Guid postId)
        {
            var post = await _postRepository.GetByIdAsync(postId)
                ?? throw new NotFoundExceptions("Post", postId);
            return new PostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                ArtistId = post.ArtistId
            };
        }

        public async Task<IEnumerable<PostResponse>> GetPostsByArtistIdAsync(Guid artistId)
        {
            var posts = await _postRepository.GetPostsByArtistIdAsync(artistId)
                ?? throw new NotFoundExceptions("Artist", artistId);
            return posts.Select(post => new PostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                ArtistId = post.ArtistId
            });
        }

        public async Task<PostResponse> UpdatePostAsync(Guid postId, UpdatePostRequest request)
        {
            var post = await _postRepository.GetByIdAsync(postId)
                ?? throw new NotFoundExceptions("Post", postId);

            if (post.Title != request.Title && await _postRepository.ExistsByTitleAsync(request.Title))
            {
                throw new ConflictException("A post with the same title already exists for this artist.");
            }

            post.Update(request.Title, request.Content);

            await _postRepository.UpdateAsync(post);

            return new PostResponse
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                ArtistId = post.ArtistId
            };
        }
    }
}
