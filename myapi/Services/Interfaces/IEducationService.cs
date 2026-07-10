using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.Education;

namespace myapi.Services.Interfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationDto>> GetEducationsAsync();
        Task<EducationDto?> GetEducationByIdAsync(int id);
        Task<EducationDto> CreateEducationAsync(CreateEducationDto dto);
        Task<bool> UpdateEducationAsync(int id, UpdateEducationDto dto);
        Task<bool> DeleteEducationAsync(int id);
    }
}