using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public SkillType Type { get; set; }
        public string? IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();
    }

    public enum SkillType
    {
        Hard = 0,
        Soft = 1
    }
}