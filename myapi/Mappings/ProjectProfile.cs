using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Project;
using myapi.Models;

namespace myapi.Mappings
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>()
            .ForMember(dest => dest.Skills,
            opt => opt.MapFrom(src => src.ProjectSkills.Select(ps => ps.Skill)))
            .ForMember(dest => dest.ProjectMedias,
            opt => opt.MapFrom(src => src.ProjectMedias));

            CreateMap<CreateProjectDto, Project>()
            .ForMember(dest => dest.ProjectSkills,
            opt => opt.Ignore())
            .ForMember(dest => dest.ProjectMedias,
            opt => opt.Ignore());

            CreateMap<UpdateProjectDto, Project>()
            .ForMember(dest => dest.ProjectSkills,
            opt => opt.Ignore())
            .ForMember(dest => dest.ProjectMedias,
            opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt,
            opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt,
            opt => opt.Ignore());

            CreateMap<ProjectMedia, ProjectMediaDto>();
            CreateMap<CreateProjectMediaDto, ProjectMedia>();
            CreateMap<UpdateProjectMediaDto, ProjectMedia>();
        }
    }
}