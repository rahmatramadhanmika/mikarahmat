using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.DTOs.Skill
{
    public class UpdateSkillDto
    {
        public string Name { get; set; } = "";
        public SkillType Type { get; set; }
        public string? IconUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}