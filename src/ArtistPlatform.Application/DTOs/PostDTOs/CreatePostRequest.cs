namespace ArtistPlatform.Application.DTOs.PostDTOs
{
    public class CreatePostRequest
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public Guid ArtistId { get; set; }
    }
}
