using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistPlatform.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ICollection<Follow> Follows { get; private set; } = new List<Follow>();


        public User(string username, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Role = UserRole.User;
            CreatedAt = DateTime.UtcNow;
        }

        public void PromoteToAdmin()
        {
            Role = UserRole.Admin;
        }

        public void SetPasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
    }
}
