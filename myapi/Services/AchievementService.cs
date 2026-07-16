using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using myapi.DTOs.Achievement;
using myapi.Exceptions;
using myapi.Models;
using myapi.Repositories.Interfaces;
using myapi.Services.Interfaces;

namespace myapi.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IAchievementRepository _achievementRepository;
        private readonly IMapper _mapper;

        public AchievementService(IAchievementRepository achievementRepository, IMapper mapper)
        {
            _achievementRepository = achievementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AchievementDto>> GetAchievementsAsync()
        {
            var achievements = await _achievementRepository.GetAchievementsAsync();

            return _mapper.Map<IEnumerable<AchievementDto>>(achievements);
        }

        public async Task<AchievementDto?> GetAchievementAsync(int id)
        {
            var achievement = await _achievementRepository.GetAchievementAsync(id);

            if (achievement == null)
            {
                throw new NotFoundException($"Achievement with ID {id} not found.");
            }

            return _mapper.Map<AchievementDto>(achievement);
        }

        public async Task<AchievementDto> CreateAchievementAsync(CreateAchievementDto dto)
        {
            var achievement = _mapper.Map<Achievement>(dto);
            
            achievement.AchievementMedias = dto.AchievementMedias.Select(m => new AchievementMedia
            {
                Url = m.Url,
                Type = m.Type,
                Caption = m.Caption,
                DisplayOrder = m.DisplayOrder
            }).ToList();

            await _achievementRepository.AddAchievementAsync(achievement);
            await _achievementRepository.SaveChangeAsync();

            return _mapper.Map<AchievementDto>(achievement);
        }

        public async Task<bool> UpdateAchievementAsync(int id, UpdateAchievementDto dto)
        {
            var achievement = await _achievementRepository.GetAchievementAsync(id);

            if (achievement == null)
            {
                throw new NotFoundException($"Achievement with ID {id} not found.");
            }

            _mapper.Map(dto, achievement);

            achievement.AchievementMedias.Clear();
            achievement.AchievementMedias = dto.AchievementMedias.Select(m => new AchievementMedia
            {
                Url = m.Url,
                Type = m.Type,
                Caption = m.Caption,
                DisplayOrder = m.DisplayOrder
            }).ToList();

            achievement.UpdatedAt = DateTime.UtcNow;

            await _achievementRepository.UpdateAchievementAsync(achievement);
            await _achievementRepository.SaveChangeAsync();

            return true;
        }

        public async Task<bool> DeleteAchievementAsync(int id)
        {
            var achievement = await _achievementRepository.GetAchievementAsync(id);

            if (achievement == null)
            {
                throw new NotFoundException("Achievement not found.");
            }

            await _achievementRepository.DeleteAchievementAsync(achievement);
            await _achievementRepository.SaveChangeAsync();

            return true;
        }
    }
}