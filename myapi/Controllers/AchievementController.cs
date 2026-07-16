using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myapi.DTOs.Achievement;
using myapi.Services.Interfaces;

namespace myapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AchievementDto>>> GetAchievement()
        {
            var achievements = await _achievementService.GetAchievementsAsync();

            return Ok(achievements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AchievementDto>> GetAchievement(int id)
        {
            var achievement = await _achievementService.GetAchievementAsync(id);

            if (achievement == null)
            {
                return NotFound();
            }

            return Ok(achievement);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult<AchievementDto>> CreateAchievement(CreateAchievementDto dto)
        {
            var achievement = await _achievementService.CreateAchievementAsync(dto);

            return CreatedAtAction(
                nameof(GetAchievement),
                new { id = achievement.Id },
                achievement);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAchievement(int id, UpdateAchievementDto dto)
        {
            await _achievementService.UpdateAchievementAsync(id, dto);

            return NoContent();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchievement(int id)
        {
            await _achievementService.DeleteAchievementAsync(id);

            return NoContent();
        }
    }
}