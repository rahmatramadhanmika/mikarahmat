using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.DTOs.Certificate;

namespace myapi.Services.Interfaces
{
    public interface ICertificateService
    {
        Task<IEnumerable<CertificateDto>> GetCertificatesAsync();
        Task<CertificateDto?> GetCertificateAsync(int id);
        Task<CertificateDto> CreateCertificateAsync( CreateCertificateDto dto);
        Task<bool> UpdateCertificateAsync(int id, UpdateCertificateDto dto);
        Task<bool> DeleteCertificateAsync(int id);
    }
}