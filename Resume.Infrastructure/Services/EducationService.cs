using Microsoft.EntityFrameworkCore;
using Resume.Application.Interfaces;
using Resume.Domain.Models;
using Resume.Infrastructure.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services
{
    public class EducationService : IEducationService
    {
        private readonly ResumeDbContext _context;

        public EducationService(ResumeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Education>> GetAllAsync() =>
    await _context.Educations.ToListAsync();

        public async Task<Education?> GetByIdAsync(Guid id) =>
            await _context.Educations.FindAsync(id);

        public async Task<Education> CreateAsync(Education item)
        {
            _context.Educations.Add(item);
     
            return item;
        }

        public async Task UpdateAsync(Education updated)
        {
            var item = await _context.Educations.FindAsync(updated.Id);
            if (item == null) throw new KeyNotFoundException();

            item.School = updated.School;
            item.Degree = updated.Degree;
            item.StartDate = updated.StartDate;
            item.EndDate = updated.EndDate;
            item.FieldOfStudy = updated.FieldOfStudy;
            item.Description = updated.Description;
            item.PersonId = updated.PersonId;

            //await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.Educations.FindAsync(id);
            if (item == null) throw new KeyNotFoundException();

            _context.Educations.Remove(item);
            //await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
           
            }   
        }

        public async Task DeleteAsync(Education item)
        {
            var deleteditem = await _context.Educations.FindAsync(item.Id);
            if (deleteditem == null) throw new KeyNotFoundException();

            _context.Educations.Remove(deleteditem);
           
        }
    }
}
 