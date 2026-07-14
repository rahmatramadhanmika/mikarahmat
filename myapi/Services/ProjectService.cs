using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Project;
using myapi.Exceptions;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;

namespace myapi.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectMediaRepository _projectMediaRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IProjectMediaRepository projectMediaRepository, ISkillRepository skillRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _projectMediaRepository = projectMediaRepository;
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
        {
            var project = await _projectRepository.GetProjectsAsync();

            return _mapper.Map<IEnumerable<ProjectDto>>(project);
        }

        public async Task<ProjectDto?> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectAsync(id);

            if (project == null)
            {
                throw new NotFoundException($"Project with ID {id} not found.");
            }

            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> CreateProjectAsync(CreateProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);

            if (dto.SkillIds.Any())
            {
                var skills = await _skillRepository.GetSkillsByIdsAsync(dto.SkillIds);

                if (skills.Count() != dto.SkillIds.Count)
                {
                    throw new BadRequestException("One or more skills do not exist.");
                }

                project.ProjectSkills = dto.SkillIds
                    .Select(id => new ProjectSkill
                    {
                        SkillId = id
                    })
                    .ToList();
            }

            project.ProjectMedias = dto.ProjectMedias.Select(m => new ProjectMedia
            {
                Url = m.Url,
                Type = m.Type,
                Caption = m.Caption,
                DisplayOrder = m.DisplayOrder
            }).ToList();

            await _projectRepository.AddProjectAsync(project);
            await _projectRepository.SaveChangeAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<bool> UpdateProjectAsync(int id, UpdateProjectDto dto)
        {
            var project = await _projectRepository.GetProjectAsync(id);

            if (project == null)
            {
                throw new NotFoundException($"Project with ID {id} not found.");
            }

            if (dto.SkillIds.Any())
            {
                var skills = await _skillRepository.GetSkillsByIdsAsync(dto.SkillIds);

                if (skills.Count() != dto.SkillIds.Count)
                {
                    throw new BadRequestException("One or more skills do not exist.");
                }
            }

            _mapper.Map(dto, project);

            project.ProjectSkills.Clear();
            project.ProjectSkills = dto.SkillIds.Select(id => new ProjectSkill
            {
                ProjectId = project.Id,
                SkillId = id
            }).ToList();

            project.ProjectMedias.Clear();
            project.ProjectMedias = dto.ProjectMedias.Select(m => new ProjectMedia
            {
                Url = m.Url,
                Type = m.Type,
                Caption = m.Caption,
                DisplayOrder = m.DisplayOrder
            }).ToList();

            project.UpdatedAt = DateTime.UtcNow;

            await _projectRepository.UpdateProjectAsync(project);
            await _projectRepository.SaveChangeAsync();

            return true;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await _projectRepository.GetProjectAsync(id);

            if (project == null)
            {
                throw new NotFoundException("Project not found.");
            }

            await _projectRepository.DeleteProjectAsync(project);
            await _projectRepository.SaveChangeAsync();

            return true;
        }
    }
}