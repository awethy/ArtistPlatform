using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Application.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
