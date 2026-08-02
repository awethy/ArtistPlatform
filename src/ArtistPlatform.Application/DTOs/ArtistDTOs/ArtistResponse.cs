using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistPlatform.Application.DTOs.ArtistDTOs
{
    public class ArtistResponse
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string Bio { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
