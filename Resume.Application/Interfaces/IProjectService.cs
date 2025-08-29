using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(Guid id);
        Task<Project> CreateAsync(Project item);
        Task<bool> SaveChangesAsync();
        Task UpdateAsync(Project item);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(Project item);
    }
}
