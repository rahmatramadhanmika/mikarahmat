using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.Auth;
using myapi.DTOs.User;

namespace myapi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> LoginAsync(LoginDto dto);
    }
}