using ArtistPlatform.Application.DTOs.AuthDTOs;
using ArtistPlatform.Application.Exceptions;
using ArtistPlatform.Application.Interfaces;
using ArtistPlatform.Application.Interfaces.Security;
using ArtistPlatform.Domain.Entities;
using ArtistPlatform.Domain.Interfaces;

namespace ArtistPlatform.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _hasherService;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthService(IUserRepository userRepository, IPasswordHasherService hasherService, IJwtTokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _hasherService = hasherService;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthResponse> Login(LoginRequest request)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);

            if (user == null)
            {
                throw new UnauthorizedException("Invalid email or password.");
            }

            if (!_hasherService.VerifyPassword(user, user.PasswordHash, request.Password))
            {
                throw new UnauthorizedException("Invalid email or password.");
            }

            var token = _tokenGenerator.GenerateToken(user);

            return new AuthResponse
            {
                Token = token,
                Role = user.Role.ToString(),
            };
        }

        public async Task<AuthResponse> Register(RegisterRequest request)
        {
            if (await _userRepository.ExistsByEmailAsync(request.Email))
            {
                throw new ConflictException($"User with email '{request.Email}' already exists.");
            }
            if (await _userRepository.ExistsByUserNameAsync(request.UserName))
            {
                throw new ConflictException($"User with username '{request.UserName}' already exists.");
            }

            var user = new User(
                request.UserName,
                request.Email,
                string.Empty
                );

            var hashPassword = _hasherService.HashPassword(user, request.Password);

            user.SetPasswordHash(hashPassword);

            await _userRepository.AddAsync(user);

            return new AuthResponse
            {

            };
        }
    }
}
