using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.DTOs.Education
{
    public class UpdateEducationDto
    {
        [Required]
        public string Institution { get; set; } = "";
        [Required]
        public string Degree { get; set; } = "";
        public string FieldOfStudy { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public string StartDate { get; set; } = "";
        public string EndDate { get; set; } = "";
        public string GPA { get; set; } = "";
        public string Location { get; set; } = "";
        public string LogoUrl { get; set; } = "";
        public bool IsCurrent { get; set; } = false;
    }
}