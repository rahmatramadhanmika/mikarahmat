using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.Models
{
    public class AchievementMedia
    {
        public int Id { get; set; }

        public int AchievementId { get; set; }

        public Achievement Achievement { get; set; } = null!;

        public string Url { get; set; } = "";

        public MediaType Type { get; set; }

        public string? Caption { get; set; }

        public int DisplayOrder { get; set; }
    }
}