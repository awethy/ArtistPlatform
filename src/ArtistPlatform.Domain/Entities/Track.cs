using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistPlatform.Domain.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string AudioUrl { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
