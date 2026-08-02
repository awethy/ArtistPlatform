using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistPlatform.Domain.Entities
{
    public class Track
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public TimeSpan Duration { get; private set; }
        public string AudioUrl { get; private set; }
        public Guid AlbumId { get; private set; }
        public Album Album { get; private set; }
        public Guid ArtistId { get; private set; }
        public Artist Artist { get; private set; }

        private Track() { }

        public Track(string title, TimeSpan duration, string audioUrl, Guid albumId, Guid artistId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Duration = duration;
            AudioUrl = audioUrl;
            AlbumId = albumId;
            ArtistId = artistId;
        }

        public void Update(string title, TimeSpan duration, string audioUrl)
        {
            Title = title;
            Duration = duration;
            AudioUrl = audioUrl;
        }
    }
}
