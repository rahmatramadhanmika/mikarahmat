using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myapi.Data;
using myapi.Models;
using myapi.Repositories.Interfaces;

namespace myapi.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly AppDbContext _context;

        public CertificateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Certificate>> GetCertificatesAsync()
        {
            return await _context.Certificates.ToListAsync();
        }

        public async Task<Certificate?> GetCertificateAsync(int id)
        {
            return await _context.Certificates.FindAsync(id);
        }

        public async Task AddCertificateAsync(Certificate certificate)
        {
            await _context.Certificates.AddAsync(certificate);
        }

        public async Task UpdateCertificateAsync(Certificate certificate)
        {
            _context.Certificates.Update(certificate);
        }

        public async Task DeleteCertificateAsync(Certificate certificate)
        {
            _context.Certificates.Remove(certificate);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}