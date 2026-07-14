using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task <IEnumerable<Project>> GetProjectsAsync();
        Task <Project?> GetProjectAsync(int id);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
        Task SaveChangeAsync();
    }
}