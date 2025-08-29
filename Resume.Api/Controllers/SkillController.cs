using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Interfaces;
using Resume.Domain.Models;


namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _context;
        public SkillController(ISkillService context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Skill>>> GetAll() =>
            await _context.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetById(Guid id)
        {
            var item = await _context.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Skill>> Create(Skill item)
        {
            _context.CreateAsync(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Skill updated)
        {
            if (id != updated.Id) return BadRequest();

            var item = await _context.GetByIdAsync(id);
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
            var item = await _context.GetByIdAsync(id);
            if (item == null) return NotFound();

            _context.DeleteAsync(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
