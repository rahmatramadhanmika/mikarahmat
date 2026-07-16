using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.Achievement;

namespace myapi.Services.Interfaces
{
    public interface IAchievementService
    {
        Task<IEnumerable<AchievementDto>> GetAchievementsAsync();
        Task<AchievementDto?> GetAchievementAsync(int id);
        Task<AchievementDto> CreateAchievementAsync(CreateAchievementDto dto);
        Task <bool> UpdateAchievementAsync(int id, UpdateAchievementDto dto);
        Task <bool> DeleteAchievementAsync(int id);
    }
}