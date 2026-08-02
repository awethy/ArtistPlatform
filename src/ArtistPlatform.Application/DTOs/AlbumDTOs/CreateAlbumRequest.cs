using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistPlatform.Application.DTOs.AlbumDTOs
{
    public class CreateAlbumRequest
    {
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid ArtistId { get; set; }
    }
}
