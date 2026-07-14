using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Repositories.Interfaces
{
    public interface IProjectMediaRepository
    {
        Task<IEnumerable<ProjectMedia>> GetProjectMediaByProjectIdAsync(int projectId);
        Task<ProjectMedia?> GetProjectMediaByIdAsync(int id);
        Task AddProjectMediaAsync(ProjectMedia media);
        Task UpdateProjectMedia(ProjectMedia media);
        Task DeleteProjectMedia(ProjectMedia media);
        Task SaveChangesAsync();
    }
}