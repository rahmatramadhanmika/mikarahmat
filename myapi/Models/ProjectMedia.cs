using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.Models
{
    public class ProjectMedia
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public string Url { get; set; } = "";
        public MediaType Type { get; set; }
        public string? Caption { get; set; }
        public int DisplayOrder { get; set; }
    }

    public enum MediaType
    {
        Image = 0,
        Video = 1
    }
}