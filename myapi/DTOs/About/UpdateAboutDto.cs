using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.DTOs.About
{
    public class UpdateAboutDto
    {
        public string FullName { get; set; } = "";
        public string Headline { get; set; } = "";
        public string Description { get; set; } = "";
        public string ProfilePictureUrl { get; set; } = "";
        public string CvUrl { get; set; } = "";
        [EmailAddress]
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Location { get; set; } = "";
    }
}