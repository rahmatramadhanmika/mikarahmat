using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Repositories.Interfaces
{
    public interface ICertificateRepository
    {
        Task <IEnumerable<Certificate>> GetCertificatesAsync();
        Task <Certificate?> GetCertificateAsync(int id);
        Task AddCertificateAsync(Certificate certificate);
        Task UpdateCertificateAsync(Certificate certificate);
        Task DeleteCertificateAsync(Certificate certificate);
        Task SaveChangesAsync();
    }
}