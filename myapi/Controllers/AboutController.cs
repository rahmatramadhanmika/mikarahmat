using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myapi.Data;
using myapi.DTOs.About;
using myapi.Models;
using myapi.Services.Interfaces;

namespace myapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutDto>>> GetAllAbout()
        {
            return Ok(await _aboutService.GetAboutsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AboutDto>> GetAbout(int id)
        {
            var about = await _aboutService.GetAboutByIdAsync(id);

            if (about == null)
            {
                return NotFound();
            }

            return Ok(about);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult<AboutDto>> CreateAbout(CreateAboutDto dto)
        {
            var about = await _aboutService.CreateAboutAsync(dto);

            return CreatedAtAction(nameof(GetAbout), new { id = about.Id }, about);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbout(int id, UpdateAboutDto dto)
        {
            var updated = await _aboutService.UpdateAboutAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var deleted = await _aboutService.DeleteAboutAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}