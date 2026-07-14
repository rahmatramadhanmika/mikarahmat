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
    public class ProjectMediaRepository : IProjectMediaRepository
{
    private readonly AppDbContext _context;

    public ProjectMediaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProjectMedia>> GetProjectMediaByProjectIdAsync(int projectId)
    {
        return await _context.ProjectMedias
            .Where(pm => pm.ProjectId == projectId)
            .OrderBy(pm => pm.DisplayOrder)
            .ToListAsync();
    }

    public async Task<ProjectMedia?> GetProjectMediaByIdAsync(int id)
    {
        return await _context.ProjectMedias
            .FirstOrDefaultAsync(pm => pm.Id == id);
    }

    public async Task AddProjectMediaAsync(ProjectMedia media)
    {
        await _context.ProjectMedias.AddAsync(media);
    }

    public async Task UpdateProjectMedia(ProjectMedia media)
    {
        _context.ProjectMedias.Update(media);
    }

    public async Task DeleteProjectMedia(ProjectMedia media)
    {
        _context.ProjectMedias.Remove(media);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
}