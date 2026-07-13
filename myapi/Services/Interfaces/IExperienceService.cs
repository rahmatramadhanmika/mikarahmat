using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.Experience;

namespace myapi.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<IEnumerable<ExperienceDto>> GetExperiencesAsync();
        Task<ExperienceDto?> GetExperienceByIdAsync(int id);
        Task<ExperienceDto> CreateExperienceAsync(CreateExperienceDto dto);
        Task<bool> UpdateExperienceAsync(int id, UpdateExperienceDto dto);
        Task<bool> DeleteExperienceAsync(int id);
    }
}