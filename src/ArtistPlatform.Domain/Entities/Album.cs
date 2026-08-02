using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistPlatform.Domain.Entities
{
    public class Album
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string CoverUrl { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Guid ArtistId { get; private set; }
        public Artist Artist { get; private set; }

        private Album() { }

        public Album(string title, string coverUrl, DateTime releaseDate, Guid artistId)
        {
            Id = Guid.NewGuid();
            Title = title;
            CoverUrl = coverUrl;
            ReleaseDate = releaseDate;
            ArtistId = artistId;
        }

        public void Update(string title, string coverUrl, DateTime releaseDate)
        {
            Title = title;
            CoverUrl = coverUrl;
            ReleaseDate = releaseDate;
        }
    }
}
