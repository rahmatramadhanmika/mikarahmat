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
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _context.Projects
            .Include(p => p.ProjectSkills)
            .ThenInclude(ps => ps.Skill)
            .Include(p => p.ProjectMedias)
            .ToListAsync();
        }

        public async Task<Project?> GetProjectAsync(int id)
        {
            return await _context.Projects
            .Include(p => p.ProjectSkills)
            .ThenInclude(ps => ps.Skill)
            .Include(p => p.ProjectMedias)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
        }

        public async Task DeleteProjectAsync(Project project)
        {
            _context.Projects.Remove(project);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}