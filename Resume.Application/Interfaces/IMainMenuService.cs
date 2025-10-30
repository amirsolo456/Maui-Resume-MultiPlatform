using Resume.Application.Dtos;
using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IMainMenuService
    {
        Task<IEnumerable<MainMenus>> GetAllAsync();
        Task<MainMenus?> GetByIdAsync(int id);
        Task<MainMenus> CreateAsync(MainMenus item);
        Task<bool> SaveChangesAsync();
        Task UpdateAsync(MainMenus item);
        Task DeleteAsync(int id);
        Task DeleteAsync(MainMenus item);
        Task DeleteAsync(IEnumerable<MainMenus> item);
    }
}
