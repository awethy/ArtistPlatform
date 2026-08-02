namespace ArtistPlatform.Application.DTOs.TrackDTOs
{
    public class CreateTrackRequest
    {
        public string Title { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public string? AudioUrl { get; set; }
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }
    }
}
