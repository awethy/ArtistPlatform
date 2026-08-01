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
        public DateTime CreatedAt { get; private set; }

        private Artist() { }

        public Artist(string name, string bio)
        {
            Id = Guid.NewGuid();
            Name = name;
            Bio = bio;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string name, string bio)
        {
            Name = name;
            Bio = bio;
        }
    }
}
