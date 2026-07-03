using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            var exists = await _repository.ExistsByEmailAsync(dto.Email);

            if (exists)
            {
                throw new Exception("Email already exists.");
            }

            var user = _mapper.Map<User>(dto);

            await _repository.AddUserAsync(user);
            await _repository.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
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