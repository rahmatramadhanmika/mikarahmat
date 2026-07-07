using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using myapi.DTOs.Auth;
using myapi.DTOs.User;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;
using System.Security.Cryptography;
using myapi.Exceptions;

namespace myapi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;
        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];

            using var rng = RandomNumberGenerator.Create();

            rng.GetBytes(randomBytes);

            return Convert.ToBase64String(randomBytes);
        }

        public AuthService(IUserRepository repository, IMapper mapper, IJwtService jwtService)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtService = jwtService;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _repository.GetUserByEmailAsync(dto.Email);

            if (user == null)
            {
                throw new BadHttpRequestException("Invalid email or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadHttpRequestException("Invalid email or password.");
            }

            var token = _jwtService.GenerateToken(user);

            var refreshToken = GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _repository.SaveChangesAsync();

            return new LoginResponseDto
            {
                Token = token,
                RefreshToken = refreshToken,
                User = _mapper.Map<UserDto>(user)
            };
        }

        public async Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenDto dto)
        {
            var user = await _repository.GetByRefreshTokenAsync(dto.RefreshToken);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid refresh token.");
            }

            if (user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new UnauthorizedAccessException("Refresh token expired.");
            }

            var token = _jwtService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                RefreshToken = user.RefreshToken!,
                User = _mapper.Map<UserDto>(user)
            };

        }
    }
}