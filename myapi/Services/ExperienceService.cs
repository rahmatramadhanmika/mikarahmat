using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Experience;
using myapi.Exceptions;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;

namespace myapi.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _repository;

        public ExperienceService(IExperienceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExperienceDto>> GetExperiencesAsync()
        {
            var experience = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<ExperienceDto>>(experience);
        }

        public async Task<ExperienceDto?> GetExperienceByIdAsync(int id)
        {
            var experience = await _repository.GetByIdAsync(id);

            if (experience == null)
            {
                throw new NotFoundException($"Experience with ID {id} not found.");
            }

            return _mapper.Map<ExperienceDto>(experience);
        }

        public async Task<ExperienceDto> CreateExperienceAsync(CreateExperienceDto dto)
        {
            var experience = _mapper.Map<Experience>(dto);

            await _repository.AddAsync(experience);
            await _repository.SaveChangeAsync();

            return _mapper.Map<ExperienceDto>(experience);
        }

        public async Task<bool> UpdateExperienceAsync(int id, UpdateExperienceDto dto)
        {
            var experience = await _repository.GetByIdAsync(id);

            if (experience == null)
            {
                throw new NotFoundException($"Experience with ID {id} not found.");
            }

            _mapper.Map(dto, experience);

            experience.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(experience);
            await _repository.SaveChangeAsync();

            return true;
        }

        public async Task<bool> DeleteExperienceAsync(int id)
        {
            var experience = await _repository.GetByIdAsync(id);

            if (experience == null)
            {
                throw new NotFoundException($"Experience with ID {id} not found.");
            }

            await _repository.DeleteAsync(experience);
            await _repository.SaveChangeAsync();

            return true;
        }
    }
}