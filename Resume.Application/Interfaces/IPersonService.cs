using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(Guid id);
        Task<Person> CreateAsync(Person item);
        Task<bool> SaveChangesAsync();
        Task<bool> AnyAsync(Guid id);
        Task UpdateAsync(Person item);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(Person item);
    }
}
