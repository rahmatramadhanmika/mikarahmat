using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myapi.Data;
using myapi.DTOs.User;
using myapi.Exceptions;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace myapi.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;
        
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _repository.GetUsersAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException($"User with ID {id} not found.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            var exists = await _repository.ExistsByEmailAsync(dto.Email);

            if (exists)
            {
                throw new BadRequestException("Email already exists.");
            }

            var user = _mapper.Map<User>(dto);

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            await _repository.AddUserAsync(user);
            await _repository.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException($"User with ID {id} not found.");
            }

            var exists = await _repository.EmailExistForOtherUserAsync(dto.Email, id);

            if (exists)
            {
                throw new BadRequestException("Email already exists.");
            }

            _mapper.Map(dto, user);

            user.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateUserAsync(user);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            await _repository.DeleteUserAsync(user);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}