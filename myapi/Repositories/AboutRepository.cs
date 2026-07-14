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
    public class AboutRepository : IAboutRepository
    {
        private readonly AppDbContext _context;

        public AboutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<About>> GetAllAsync()
        {
            return await _context.About.ToListAsync();
        }

        public async Task<About?> GetByIdAsync(int id)
        {
            return await _context.About.FindAsync(id);
        }

        public async Task AddAsync(About about)
        {
            await _context.About.AddAsync(about);
        }

        public async Task UpdateAsync(About about)
        {
            _context.About.Update(about);
        }

        public async Task DeleteAsync(About about)
        {
            _context.About.Remove(about);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}