using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Education;
using myapi.Exceptions;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;

namespace myapi.Services
{
    public class EducationService : IEducationService
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _repository;

        public EducationService(IEducationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EducationDto>> GetEducationsAsync()
        {
            var education = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<EducationDto>>(education);
        }

        public async Task<EducationDto?> GetEducationByIdAsync(int id)
        {
            var education = await _repository.GetByIdAsync(id);

            if (education == null)
            {
                throw new NotFoundException($"Education with ID {id} not found.");
            }

            return _mapper.Map<EducationDto>(education);
        }

        public async Task<EducationDto> CreateEducationAsync(CreateEducationDto dto)
        {
            var education = _mapper.Map<Education>(dto);

            await _repository.AddAsync(education);
            await _repository.SaveChangeAsync();

            return _mapper.Map<EducationDto>(education);
        }

        public async Task<bool> UpdateEducationAsync(int id, UpdateEducationDto dto)
        {
            var education = await _repository.GetByIdAsync(id);

            if (education == null)
            {
                throw new NotFoundException($"Education with ID {id} not found.");
            }

            _mapper.Map(dto, education);

            education.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(education);
            await _repository.SaveChangeAsync();

            return true;
        }

        public async Task<bool> DeleteEducationAsync(int id)
        {
            var education = await _repository.GetByIdAsync(id);

            if (education == null)
            {
                throw new NotFoundException($"Education with ID {id} not found.");
            }

            await _repository.DeleteAsync(education);
            await _repository.SaveChangeAsync();

            return true;
        }
    }
}