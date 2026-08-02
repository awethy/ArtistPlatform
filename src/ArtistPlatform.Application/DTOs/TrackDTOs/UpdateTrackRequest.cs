namespace ArtistPlatform.Application.DTOs.TrackDTOs
{
    public class UpdateTrackRequest
    {
        public string Title { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public string? AudioUrl { get; set; }
    }
}
