namespace ArtistPlatform.Application.DTOs.AlbumDTOs
{
    public class AlbumResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid ArtistId { get; set; }
    }
}
