using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Repositories.Interfaces
{
    public interface IAchievementRepository
    {
        Task <IEnumerable<Achievement>> GetAchievementsAsync();
        Task <Achievement?> GetAchievementAsync(int id);
        Task AddAchievementAsync(Achievement achievement);
        Task UpdateAchievementAsync(Achievement achievement);
        Task DeleteAchievementAsync(Achievement achievement);
        Task SaveChangeAsync();
    }
}