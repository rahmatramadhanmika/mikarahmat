using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}