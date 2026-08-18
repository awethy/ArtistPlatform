using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistPlatform.Domain.Entities
{
    public class Artist
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Bio { get; private set; }
        public string AvatarUrl { get; private set; }
        public string Genre {  get; private set; }
        public string Country { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public List<Album> Albums { get; private set; }
        public List<Track> Tracks {  get; private set; }

        public ICollection<Follow> Followers { get; private set; } = new List<Follow>();

        private Artist() { }

        public Artist(string name, string bio, string avatarUrl, string genre, string country)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bio = bio;
            CreatedAt = DateTime.UtcNow;
            AvatarUrl = avatarUrl;
            Genre = genre;
            Country = country;
        }

        public void Update(string name, string bio, string avatarUrl, string genre, string country)
        {
            Name = name;
            Bio = bio;
            AvatarUrl = avatarUrl;
            Genre = genre;
            Country = country;
        }
    }
}
