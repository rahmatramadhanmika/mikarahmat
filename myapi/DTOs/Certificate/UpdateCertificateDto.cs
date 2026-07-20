using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myapi.DTOs.Certificate
{
    public class UpdateCertificateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Issuer { get; set; } = "";
        public DateOnly IssueDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public string? CredentialId { get; set; }
        public string? CredentialUrl { get; set; }
        public string? ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}