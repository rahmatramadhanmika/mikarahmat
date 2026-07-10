using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.DTOs.Education
{
    public class EducationDto
    {
        public int Id { get; set; }
        public string Institution { get; set; } = "";
        public string Degree { get; set; } = "";
        public string FieldOfStudy { get; set; } = "";
        public string Description { get; set; } = "";
        public string StartDate { get; set; } = "";
        public string EndDate { get; set; } = "";
        public string GPA { get; set; } = "";
        public string Location { get; set; } = "";
        public string LogoUrl { get; set; } = "";
        public bool IsCurrent { get; set; } = false;
    }
}