using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.DTOs.Experience
{
    public class CreateExperienceDto
    {
        public string Company { get; set; } = "";
        public string Position { get; set; } = "";
        public string EmploymentType { get; set; } = "";
        public string Location { get; set; } = "";
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool IsCurrent { get; set; } = false;
        public string Description { get; set; } = "";
        public string CompanyLogoUrl { get; set; } = "";
        public string CompanyWebsite { get; set; } = "";
    }
}