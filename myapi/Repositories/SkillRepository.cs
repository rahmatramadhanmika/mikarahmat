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
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _context;

        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skill?> GetByIdAsync(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task<IEnumerable<Skill>> GetSkillsByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Skills
                .Where(s => ids.Contains(s.Id))
                .ToListAsync();
        }

        public async Task AddAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public async Task UpdateAsync(Skill skill)
        {
            _context.Skills.Update(skill);
        }

        public async Task DeleteAsync(Skill skill)
        {
            _context.Skills.Remove(skill);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}