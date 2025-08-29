using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IWorkExperienceService
    {
        Task<List<WorkExperience>> GetAllAsync();
        Task<WorkExperience?> GetByIdAsync(Guid id);
        Task<WorkExperience> CreateAsync(WorkExperience item);
        Task<bool> SaveChangesAsync();
        Task UpdateAsync(WorkExperience item);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(WorkExperience item);
    }
}
