using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace myapi.DTOs.About
{
    public class CreateAboutDto
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