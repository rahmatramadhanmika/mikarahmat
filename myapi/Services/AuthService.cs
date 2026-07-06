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

namespace myapi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<UserDto> LoginAsync(LoginDto dto)
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

            return _mapper.Map<UserDto>(user);
        }
    }
}