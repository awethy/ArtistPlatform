using ArtistPlatform.Application.DTOs.AlbumDTOs;
using ArtistPlatform.Application.DTOs.TrackDTOs;

namespace ArtistPlatform.Application.DTOs.ArtistDTOs
{
    public class ArtistResponse
    {
        public required Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AvatarUrl { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }

        public List<AlbumResponse> Albums { get; set; }
        public List<TrackResponse> Tracks { get; set; }

        public int FollowersCount { get; set; }
    }
}
