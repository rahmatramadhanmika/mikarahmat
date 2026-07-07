using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.User;

namespace myapi.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = "";
        public string RefreshToken { get; set; } = "";
        public UserDto User { get; set; } = null!;
    }
}