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
    public class ProjectService : IProjectService
    {
        private readonly ResumeDbContext _context;

        public ProjectService(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateAsync(Project item)
        {
            _context.Projects.Add(item);
            return item; // هنوز ذخیره نشده
        }

        public async Task UpdateAsync(Project updated)
        {
            var item = await _context.Projects.FindAsync(updated.Id);
            if (item == null) throw new KeyNotFoundException();

            _context.Entry(updated).State = EntityState.Modified;
            // تغییرات هنوز ذخیره نشده
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.Projects.FindAsync(id);
            if (item == null) throw new KeyNotFoundException();

            _context.Projects.Remove(item);
            // تغییرات هنوز ذخیره نشده
        }

        public async Task DeleteAsync(Project item)
        {
            var deletedItem = await _context.Projects.FindAsync(item.Id);
            if (deletedItem == null) throw new KeyNotFoundException();

            _context.Projects.Remove(deletedItem);
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

        public async Task<List<Project>> GetAllAsync() =>
            await _context.Projects.ToListAsync();

        public async Task<Project?> GetByIdAsync(Guid id) =>
            await _context.Projects
                .Include(x => x.Person) // اگر رابطه با Person وجود داره
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> AnyAsync(Guid id) =>
            await _context.Projects.AnyAsync(e => e.Id == id);
    }
}
