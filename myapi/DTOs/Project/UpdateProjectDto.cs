using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.Skill;

namespace myapi.DTOs.Project
{
    public class UpdateProjectDto
    {
        public string Title { get; set; } = "";
        public string Slug { get; set; } = "";
        public string Description { get; set; } = "";
        public string? GithubUrl { get; set; }
        public string? LiveDemoUrl { get; set; }
        public bool IsFeatured { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public List<int> SkillIds { get; set; } = [];
        public List<UpdateProjectMediaDto> ProjectMedias { get; set; } = [];
    }
}