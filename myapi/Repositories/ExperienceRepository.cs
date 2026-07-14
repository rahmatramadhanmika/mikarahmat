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
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly AppDbContext _context;

        public ExperienceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Experience>> GetAllAsync()
        {
            return await _context.Experiences.ToListAsync();
        }

        public async Task<Experience?> GetByIdAsync(int id)
        {
            return await _context.Experiences.FindAsync(id);
        }

        public async Task AddAsync(Experience experience)
        {
            await _context.Experiences.AddAsync(experience);
        }

        public async Task UpdateAsync(Experience experience)
        {
            _context.Experiences.Update(experience);
        }

        public async Task DeleteAsync(Experience experience)
        {
            _context.Experiences.Remove(experience);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}