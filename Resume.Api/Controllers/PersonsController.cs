using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Interfaces;
using Resume.Domain.Models;
using System;
using System.Threading.Tasks;


namespace Resume.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _context;
        public PersonsController(IPersonService db) => _context = db;


        // GET: api/persons
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _context.GetAllAsync();
            return Ok(persons);
        }

        // GET: api/persons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var person = await _context.GetByIdAsync(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST: api/persons
        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            _context.CreateAsync(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        // PUT: api/persons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Person person)
        {
            if (id !=  person.Id)
                return BadRequest();



            try
            {
                await _context.CreateAsync(person);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PersonExists(id))
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
            //var person = await _context.DeleteAsync(id);
            //if (person == null)
            //    return NotFound();
            try
            {
                await _context.DeleteAsync(id);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            
            }           
        }

        private async Task<bool> PersonExists(Guid id)
        {
            return await _context.AnyAsync(id);
        }
    }
}
