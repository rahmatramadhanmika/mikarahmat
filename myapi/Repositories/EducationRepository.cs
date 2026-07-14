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
    public class EducationRepository : IEducationRepository
    {
        private readonly AppDbContext _context;

        public EducationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            return await _context.Education.ToListAsync();
        }

        public async Task<Education?> GetByIdAsync(int id)
        {
            return await _context.Education.FindAsync(id);
        }

        public async Task AddAsync(Education education)
        {
            await _context.Education.AddAsync(education);
        }

        public async Task UpdateAsync(Education education)
        {
            _context.Education.Update(education);
        }

        public async Task DeleteAsync(Education education)
        {
            _context.Education.Remove(education);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}