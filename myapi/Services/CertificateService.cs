using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Certificate;
using myapi.Exceptions;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;

namespace myapi.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly IMapper _mapper;
        private readonly ICertificateRepository _repository;

        public CertificateService(ICertificateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CertificateDto>> GetCertificatesAsync()
        {
            var certificates = await _repository.GetCertificatesAsync();

            return _mapper.Map<IEnumerable<CertificateDto>>(certificates);
        }

        public async Task<CertificateDto?> GetCertificateAsync(int id)
        {
            var certificate = await _repository.GetCertificateAsync(id);

            if (certificate == null)
            {
                throw new NotFoundException($"Certificate with ID {id} not found.");
            }

            return _mapper.Map<CertificateDto>(certificate);
        }

        public async Task<CertificateDto> CreateCertificateAsync(CreateCertificateDto dto)
        {
            var certificate = _mapper.Map<Certificate>(dto);

            await _repository.AddCertificateAsync(certificate);
            await _repository.SaveChangesAsync();

            return _mapper.Map<CertificateDto>(certificate);
        }

        public async Task<bool> UpdateCertificateAsync(int id, UpdateCertificateDto dto)
        {
            var certificate = await _repository.GetCertificateAsync(id);

            if (certificate == null)
            {
                throw new NotFoundException($"Certificate with ID {id} not found.");
            }

            _mapper.Map(dto, certificate);
            certificate.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateCertificateAsync(certificate);
            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCertificateAsync(int id)
        {
            var certificate = await _repository.GetCertificateAsync(id);

            if (certificate == null)
            {
                throw new NotFoundException($"Certificate with ID {id} not found.");
            }

            await _repository.DeleteCertificateAsync(certificate);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}