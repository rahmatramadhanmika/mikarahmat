using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.Models
{
    public class About
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Headline { get; set; } = "";
        public string Description { get; set; } = "";
        public string ProfilePictureUrl { get; set; } = "";
        public string CvUrl { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Location { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}