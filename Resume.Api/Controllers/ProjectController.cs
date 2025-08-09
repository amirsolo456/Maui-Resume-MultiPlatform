using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Core.Models;

namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ResumeDbContext _context;
        public ProjectController(ResumeDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAll() =>
            await _context.Projects.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetById(Guid id)
        {
            var item = await _context.Projects.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Create(Project item)
        {
            _context.Projects.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Project updated)
        {
            if (id != updated.Id) return BadRequest();

            var item = await _context.Projects.FindAsync(id);
            if (item == null) return NotFound();

            item.Title = updated.Title;
            item.Description = updated.Description;
            item.Url = updated.Url;
            item.PersonId = updated.PersonId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.Projects.FindAsync(id);
            if (item == null) return NotFound();

            _context.Projects.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }

}
