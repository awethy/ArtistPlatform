using ArtistPlatform.Domain.Entities;

namespace ArtistPlatform.Application.Interfaces.Security
{
    public interface IPasswordHasherService
    {
        string HashPassword(User user, string password);
    }
}
