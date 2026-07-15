using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.DTOs.Achievement
{
    public class AchievementDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? Issuer { get; set; }
        public string Description { get; set; } = "";
        public string? Location { get; set; }
        public DateOnly? Date { get; set; }
        public string? CredentialUrl { get; set; }
        public int DisplayOrder { get; set; }
        public List<AchievementMediaDto> AchievementMedias { get; set; } = [];
    }
}