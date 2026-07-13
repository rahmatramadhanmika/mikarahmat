using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myapi.DTOs.Education;
using myapi.Models;
using myapi.Services.Interfaces;

namespace myapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationDto>>> GetEducations()
        {
            return Ok(await _educationService.GetEducationsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationDto>> GetEducation(int id)
        {
            var education = await _educationService.GetEducationByIdAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult<Education>> CreateEducation(CreateEducationDto dto)
        {
            var education = await _educationService.CreateEducationAsync(dto);

            return CreatedAtAction(nameof(GetEducation), new { id = education.Id }, education);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEducation(int id, UpdateEducationDto dto)
        {
            var updated = await _educationService.UpdateEducationAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var deleted = await _educationService.DeleteEducationAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}