using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Interfaces;
using Resume.Domain.Models;

namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkExperienceController : ControllerBase
    {
        private readonly IWorkExperienceService _context;
        public WorkExperienceController(IWorkExperienceService context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<WorkExperience>>> GetAll() =>
            await _context.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkExperience>> GetById(Guid id)
        {
            var item = await _context.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<WorkExperience>> Create(WorkExperience item)
        {
            _context.CreateAsync(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, WorkExperience updated)
        {
            if (id != updated.Id) return BadRequest();

            var item = await _context.GetByIdAsync(id);
            if (item == null) return NotFound();

            item.Company = updated.Company;
            item.Position = updated.Position;
            item.StartDate = updated.StartDate;
            item.EndDate = updated.EndDate;
            item.Description = updated.Description;
            item.PersonId = updated.PersonId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.GetByIdAsync(id);
            if (item == null) return NotFound();

            _context.DeleteAsync(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
