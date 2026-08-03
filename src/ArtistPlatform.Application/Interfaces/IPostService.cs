using ArtistPlatform.Application.DTOs.PostDTOs;

namespace ArtistPlatform.Application.Interfaces
{
    public interface IPostService
    {
        Task<PostResponse> CreatePostAsync(CreatePostRequest request);
        Task<PostResponse> GetPostByIdAsync(Guid postId);
        Task<IEnumerable<PostResponse>> GetAllPostsAsync();
        Task<IEnumerable<PostResponse>> GetPostsByArtistIdAsync(Guid artistId);
        Task<PostResponse> UpdatePostAsync(Guid postId, UpdatePostRequest request);
        Task DeletePostAsync(Guid postId);
    }
}
