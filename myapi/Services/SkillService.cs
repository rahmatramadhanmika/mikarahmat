using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Skill;
using myapi.Exceptions;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;

namespace myapi.Services
{
    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillDto>> GetSkillsAsync()
        {
            var skill = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<SkillDto>>(skill);
        }

        public async Task<SkillDto?> GetSkillByIdAsync(int id)
        {
            var skill = await _repository.GetByIdAsync(id);

            if (skill == null)
            {
                throw new NotFoundException($"Skill with ID {id} not found.");
            }

            return _mapper.Map<SkillDto>(skill);
        }

        public async Task<SkillDto> CreateSkillAsync(CreateSkillDto dto)
        {
            var skill = _mapper.Map<Skill>(dto);

            await _repository.AddAsync(skill);
            await _repository.SaveChangeAsync();

            return _mapper.Map<SkillDto>(skill);
        }

        public async Task<bool> UpdateSkillAsync(int id, UpdateSkillDto dto)
        {
            var skill = await _repository.GetByIdAsync(id);

            if (skill == null)
            {
                throw new NotFoundException($"Skill with ID {id} not found.");
            }

            _mapper.Map(dto, skill);

            skill.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(skill);
            await _repository.SaveChangeAsync();

            return true;
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await _repository.GetByIdAsync(id);

            if (skill == null)
            {
                throw new NotFoundException($"Skill with ID {id} not found.");
            }

            await _repository.DeleteAsync(skill);
            await _repository.SaveChangeAsync();

            return true;
        }
    }
}