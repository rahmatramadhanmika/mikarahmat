using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myapi.DTOs.Certificate;
using myapi.Services.Interfaces;

namespace myapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificateDto>>> GetCertificates()
        {
            return Ok(await _certificateService.GetCertificatesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateDto>> GetCertificate(int id)
        {
            var certificate = await _certificateService.GetCertificateAsync(id);

            if (certificate == null)
            {
                return NotFound();
            }

            return Ok(certificate);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<ActionResult<CertificateDto>> CreateCertificate(CreateCertificateDto dto)
        {
            var certificate = await _certificateService.CreateCertificateAsync(dto);

            return CreatedAtAction(nameof(GetCertificate), new { id = certificate.Id }, certificate);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCertificate(int id, UpdateCertificateDto dto)
        {
            var updated = await _certificateService.UpdateCertificateAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var deleted = await _certificateService.DeleteCertificateAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}