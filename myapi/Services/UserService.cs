using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myapi.Data;
using myapi.DTOs.User;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;

namespace myapi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _repository.GetUsersAsync();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                IsAdmin = u.IsAdmin
            });
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                IsAdmin = user.IsAdmin
            };
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            var exists = await _repository.ExistsByEmailAsync(dto.Email);

            if (exists)
            {
                throw new Exception("Email already exists.");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password, // In a real application, hash the password before storing it
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsAdmin = false // Default to non-admin
            };

            await _repository.AddUserAsync(user);
            await _repository.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                IsAdmin = user.IsAdmin
            };
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _repository.GetUserByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            var exists = await _repository.EmailExistForOtherUserAsync(dto.Email, id);

            if (exists)
            {
                throw new Exception("Email already exists.");
            }

            user.Name = dto.Name;
            user.Email = dto.Email;
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