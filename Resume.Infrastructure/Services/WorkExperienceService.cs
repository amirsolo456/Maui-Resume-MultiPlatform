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
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly ResumeDbContext _context;

        public WorkExperienceService(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task<WorkExperience> CreateAsync(WorkExperience item)
        {
            _context.WorkExperiences.Add(item);
            return item; // هنوز ذخیره نشده
        }

        public async Task UpdateAsync(WorkExperience updated)
        {
            var item = await _context.WorkExperiences.FindAsync(updated.Id);
            if (item == null) throw new KeyNotFoundException();

            _context.Entry(updated).State = EntityState.Modified;
            // تغییرات هنوز ذخیره نشده
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.WorkExperiences.FindAsync(id);
            if (item == null) throw new KeyNotFoundException();

            _context.WorkExperiences.Remove(item);
            // تغییرات هنوز ذخیره نشده
        }

        public async Task DeleteAsync(WorkExperience item)
        {
            var deletedItem = await _context.WorkExperiences.FindAsync(item.Id);
            if (deletedItem == null) throw new KeyNotFoundException();

            _context.WorkExperiences.Remove(deletedItem);
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

        public async Task<List<WorkExperience>> GetAllAsync() =>
            await _context.WorkExperiences.ToListAsync();

        public async Task<WorkExperience?> GetByIdAsync(Guid id) =>
            await _context.WorkExperiences
                .Include(x => x.Person) // اگر رابطه با Person وجود دارد
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> AnyAsync(Guid id) =>
            await _context.WorkExperiences.AnyAsync(e => e.Id == id);
    }
}
