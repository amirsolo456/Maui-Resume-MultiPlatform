using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Core.Models;
using Resume.Infrastructure;

namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkExperienceController : ControllerBase
    {
        private readonly ResumeDbContext _context;
        public WorkExperienceController(ResumeDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<WorkExperience>>> GetAll() =>
            await _context.WorkExperiences.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkExperience>> GetById(Guid id)
        {
            var item = await _context.WorkExperiences.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<WorkExperience>> Create(WorkExperience item)
        {
            _context.WorkExperiences.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, WorkExperience updated)
        {
            if (id != updated.Id) return BadRequest();

            var item = await _context.WorkExperiences.FindAsync(id);
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
            var item = await _context.WorkExperiences.FindAsync(id);
            if (item == null) return NotFound();

            _context.WorkExperiences.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
