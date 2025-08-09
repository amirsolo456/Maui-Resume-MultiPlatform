using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Core.Models;

namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ResumeDbContext _context;
        public SkillController(ResumeDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Skill>>> GetAll() =>
            await _context.Skills.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetById(Guid id)
        {
            var item = await _context.Skills.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> Create(Skill item)
        {
            _context.Skills.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Skill updated)
        {
            if (id != updated.Id) return BadRequest();

            var item = await _context.Skills.FindAsync(id);
            if (item == null) return NotFound();

            item.Name = updated.Name;
            item.Level = updated.Level;
            item.PersonId = updated.PersonId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.Skills.FindAsync(id);
            if (item == null) return NotFound();

            _context.Skills.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
