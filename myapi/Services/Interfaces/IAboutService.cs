using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.About;

namespace myapi.Services.Interfaces
{
    public interface IAboutService
    {
        Task<IEnumerable<AboutDto>> GetAboutsAsync();
        Task<AboutDto?> GetAboutByIdAsync(int id);
        Task<AboutDto> CreateAboutAsync(CreateAboutDto dto);
        Task<bool> UpdateAboutAsync(int id, UpdateAboutDto dto);
        Task<bool> DeleteAboutAsync(int id);
    }
}