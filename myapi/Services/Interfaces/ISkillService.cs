using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.Skill;

namespace myapi.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDto>> GetSkillsAsync();
        Task<SkillDto?> GetSkillByIdAsync(int id);
        Task<SkillDto> CreateSkillAsync(CreateSkillDto dto);
        Task<bool> UpdateSkillAsync(int id, UpdateSkillDto dto);
        Task<bool> DeleteSkillAsync(int id);
    }
}