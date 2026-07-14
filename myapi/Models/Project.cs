using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Slug { get; set; } = "";
        public string Description { get; set; } = "";
        public string? GithubUrl { get; set; }
        public string? LiveDemoUrl { get; set; }
        public bool IsFeatured { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();

        public ICollection<ProjectMedia> ProjectMedias { get; set; } = new List<ProjectMedia>();
    }
}