using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.Project;

namespace myapi.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetProjectsAsync();

        Task<ProjectDto?> GetProjectByIdAsync(int id);

        Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto);

        Task<bool> UpdateProjectAsync(int id, UpdateProjectDto dto);

        Task<bool> DeleteProjectAsync(int id);
    }
}