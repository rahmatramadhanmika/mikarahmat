using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.User;

namespace myapi.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();

        Task<UserDto?> GetUserByIdAsync(int id);

        Task<UserDto> CreateUserAsync(CreateUserDto dto);

        Task<bool> UpdateUserAsync(int id, UpdateUserDto dto);
        
        Task<bool> DeleteUserAsync(int id);
    }
}