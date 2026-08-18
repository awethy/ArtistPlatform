namespace ArtistPlatform.Domain.Entities
{
    public class Follow
    {
        public Guid UserId { get; private set; }
        public Guid ArtistId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public User User { get; private set; } = null!;
        public Artist Artist { get; private set; } = null!;

        private Follow() { }

        public Follow(Guid userId, Guid artistId)
        {
            UserId = userId;
            ArtistId = artistId;
            CreatedAt = DateTime.Now;
        }
    }
}
