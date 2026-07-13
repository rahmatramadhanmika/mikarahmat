using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myapi.DTOs.Experience;
using myapi.Models;
using myapi.Services.Interfaces;

namespace myapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceServie;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceServie = experienceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienceDto>>> GetExperiences()
        {
            return Ok(await _experienceServie.GetExperiencesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienceDto>> GetExperience(int id)
        {
            var experience = await _experienceServie.GetExperienceByIdAsync(id);

            if (experience == null)
            {
                return NotFound();
            }

            return Ok(experience);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult<Experience>> CreateExperience(CreateExperienceDto dto)
        {
            var experience = await _experienceServie.CreateExperienceAsync(dto);

            return CreatedAtAction(nameof(GetExperience), new { id = experience.Id }, experience);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExperience(int id, UpdateExperienceDto dto)
        {
            var updated = await _experienceServie.UpdateExperienceAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var deleted = await _experienceServie.DeleteExperienceAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}