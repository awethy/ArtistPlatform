namespace ArtistPlatform.Application.DTOs.AuthDTOs
{
    public class AuthResponse
    {
        public string Token { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;
    }
}
