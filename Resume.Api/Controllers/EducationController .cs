using Microsoft.AspNetCore.Mvc;
using Resume.Application.Interfaces;
using Resume.Domain.Models;


namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _context;
        public EducationController(IEducationService context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Education>>> GetAll()
        {
          return  await _context.GetAllAsync();
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<Education>> GetById(Guid id)
        {
            var item = await _context.GetByIdAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Education>> Create(Education item)
        {
            _context.CreateAsync(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Education updated)
        {
            if (id != updated.Id) return BadRequest();

            var item = await _context.GetByIdAsync(id);
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
            var item = await _context.GetByIdAsync(id);
            if (item == null) return NotFound();

            _context.DeleteAsync(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
