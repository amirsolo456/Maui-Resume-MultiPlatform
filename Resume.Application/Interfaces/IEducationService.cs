using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IEducationService
    {
        Task<List<Education>> GetAllAsync();
        Task<Education?> GetByIdAsync(Guid id);
        Task<Education> CreateAsync(Education item);
        Task<bool> SaveChangesAsync();
        Task UpdateAsync(Education item);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(Education item);

    }
}
