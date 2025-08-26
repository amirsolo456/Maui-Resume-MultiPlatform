using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Infrastructure.DBContext;
using Resume.Core.Models;
using Resume.Infrastructure;

namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly ResumeDbContext _context;
        private readonly ResumeDbContext _db;
        public PersonsController(ResumeDbContext db) => _db = db;
 

        // GET: api/persons
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _context.Persons.ToListAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var p = await _db.Persons
                .Include(x => x.WorkExperiences)
                .Include(x => x.Educations)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        // GET: api/persons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST: api/persons
        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        // PUT: api/persons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Person person)
        {
            if (id !=  person.Id)
                return BadRequest();

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
