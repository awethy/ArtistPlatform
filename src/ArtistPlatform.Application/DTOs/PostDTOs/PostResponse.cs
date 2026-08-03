namespace ArtistPlatform.Application.DTOs.PostDTOs
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid ArtistId { get; set; }
    }
}
