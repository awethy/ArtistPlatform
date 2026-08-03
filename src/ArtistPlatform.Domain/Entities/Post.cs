namespace ArtistPlatform.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid ArtistId { get; private set; }
        public Artist Artist { get; private set; }

        private Post() { } // For EF Core

        public Post(string title, string content, Guid artistId)
        {
            Title = title;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            ArtistId = artistId;
        }

        public void Update(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
