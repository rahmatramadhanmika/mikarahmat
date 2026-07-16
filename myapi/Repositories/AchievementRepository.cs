using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myapi.Data;
using myapi.Models;
using myapi.Repositories.Interfaces;

namespace myapi.Repositories
{
    public class AchievementRepository : IAchievementRepository
    {
        private readonly AppDbContext _context;

        public AchievementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Achievement>> GetAchievementsAsync()
        {
            return await _context.Achievements
            .Include(a => a.AchievementMedias)
            .ToListAsync();
        }

        public async Task<Achievement?> GetAchievementAsync(int id)
        {
            return await _context.Achievements
            .Include(a => a.AchievementMedias)
            .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAchievementAsync(Achievement achievement)
        {
            await _context.Achievements.AddAsync(achievement);
        }

        public async Task UpdateAchievementAsync(Achievement achievement)
        {
            _context.Achievements.Update(achievement);
        }

        public async Task DeleteAchievementAsync(Achievement achievement)
        {
            _context.Achievements.Remove(achievement);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}