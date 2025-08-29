using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(Guid id);
        Task<Skill> CreateAsync(Skill item);
        Task<bool> SaveChangesAsync();
        Task UpdateAsync(Skill item);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(Skill item);
    }
}
