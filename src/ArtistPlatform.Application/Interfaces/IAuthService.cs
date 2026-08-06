using ArtistPlatform.Application.DTOs.AuthDTOs;

namespace ArtistPlatform.Application.Interfaces
{
    public interface IAuthService
    {
        public Task<AuthResponse> Register(RegisterRequest request);
        public Task<AuthResponse> Login(LoginRequest request);
    }
}
