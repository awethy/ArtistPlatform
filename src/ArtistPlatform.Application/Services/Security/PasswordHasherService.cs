using ArtistPlatform.Application.Interfaces.Security;
using ArtistPlatform.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ArtistPlatform.Application.Services.Security
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<User> _passwordHasher = new();

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }
    }
}
