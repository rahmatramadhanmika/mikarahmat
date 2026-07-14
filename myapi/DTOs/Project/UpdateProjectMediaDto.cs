using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.DTOs.Project
{
    public class UpdateProjectMediaDto
    {
        public int? Id { get; set; }

        public string Url { get; set; } = "";

        public MediaType Type { get; set; }

        public string? Caption { get; set; }

        public int DisplayOrder { get; set; }
    }
}