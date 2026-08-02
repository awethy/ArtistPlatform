using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistPlatform.Application.DTOs.ArtistDTOs
{
    public class UpdateArtistRequest
    {
        public required string Name { get; set; }
        public string Bio { get; set; }
    }
}
