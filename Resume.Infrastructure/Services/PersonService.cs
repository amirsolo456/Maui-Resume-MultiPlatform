using Microsoft.EntityFrameworkCore;
using Resume.Application.Interfaces;
using Resume.Domain.Models;
using Resume.Infrastructure.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services
{
    public class PersonService : IPersonService
    {
        private readonly ResumeDbContext _context;

        public PersonService(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreateAsync(Person item)
        {
            _context.Persons.Add(item);
            return item; // تغییرات هنوز ذخیره نشده
        }

        public async Task UpdateAsync(Person updated)
        {
            var item = await _context.Persons.FindAsync(updated.Id);
            if (item == null) throw new KeyNotFoundException();

            // حالت ساده با EF: فقط Entity رو Attach می‌کنیم و State رو Modified می‌کنیم
            _context.Entry(updated).State = EntityState.Modified;

            // تغییرات هنوز ذخیره نشده؛ SaveChangesAsync باید صدا زده شود
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.Persons.FindAsync(id);
            if (item == null) throw new KeyNotFoundException();

            _context.Persons.Remove(item);
            // تغییرات هنوز ذخیره نشده
        }

        public async Task DeleteAsync(Person item)
        {
            var deletedItem = await _context.Persons.FindAsync(item.Id);
            if (deletedItem == null) throw new KeyNotFoundException();

            _context.Persons.Remove(deletedItem);
            // تغییرات هنوز ذخیره نشده
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Person>> GetAllAsync() =>
            await _context.Persons.ToListAsync();

        public async Task<Person?> GetByIdAsync(Guid id) =>
            await _context.Persons
                .Include(x => x.WorkExperiences)
                .Include(x => x.Educations)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> AnyAsync(Guid id) =>
            await _context.Persons.AnyAsync(e => e.Id == id);
    }
}
