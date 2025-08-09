using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Core.Models;

namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly ResumeDbContext _context;
        public EducationController(ResumeDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Education>>> GetAll() =>
            await _context.Educations.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetById(Guid id)
        {
            var item = await _context.Educations.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Education>> Create(Education item)
        {
            _context.Educations.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Education updated)
        {
            if (id != updated.Id) return BadRequest();

            var item = await _context.Educations.FindAsync(id);
            if (item == null) return NotFound();

            item.School = updated.School;
            item.Degree = updated.Degree;
            item.StartDate = updated.StartDate;
            item.EndDate = updated.EndDate;
            item.FieldOfStudy = updated.FieldOfStudy;
            item.Description = updated.Description;
            item.PersonId = updated.PersonId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.Educations.FindAsync(id);
            if (item == null) return NotFound();

            _context.Educations.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
