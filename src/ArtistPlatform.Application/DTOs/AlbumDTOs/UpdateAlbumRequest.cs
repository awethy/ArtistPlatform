namespace ArtistPlatform.Application.DTOs.AlbumDTOs
{
    public class UpdateAlbumRequest
    {
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
