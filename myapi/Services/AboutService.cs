using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myapi.Data;
using myapi.DTOs.About;
using myapi.Exceptions;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;

namespace myapi.Services
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _mapper;
        private readonly IAboutRepository _repository;

        public AboutService(IAboutRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AboutDto>> GetAboutsAsync()
        {
            var about = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<AboutDto>>(about);
        }

        public async Task<AboutDto?> GetAboutByIdAsync(int id)
        {
            var about = await _repository.GetByIdAsync(id);

            if (about == null)
            {
                throw new NotFoundException($"About with ID {id} not found.");
            }

            return _mapper.Map<AboutDto>(about);
        }

        public async Task<AboutDto> CreateAboutAsync(CreateAboutDto dto)
        {
            var about = _mapper.Map<About>(dto);

            await _repository.AddAsync(about);
            await _repository.SaveChangeAsync();

            return _mapper.Map<AboutDto>(about);
        }

        public async Task<bool> UpdateAboutAsync(int id, UpdateAboutDto dto)
        {
            var about = await _repository.GetByIdAsync(id);

            if (about == null)
            {
                throw new NotFoundException($"About with ID {id} not found.");
            }

            _mapper.Map(dto, about);

            about.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(about);
            await _repository.SaveChangeAsync();
            return true;
        }

        public async Task<bool> DeleteAboutAsync(int id)
        {
            var about = await _repository.GetByIdAsync(id);

            if (about == null)
            {
                throw new NotFoundException($"About with ID {id} not found.");
            }

            await _repository.DeleteAsync(about);
            await _repository.SaveChangeAsync();

            return true;
        }
    }
}