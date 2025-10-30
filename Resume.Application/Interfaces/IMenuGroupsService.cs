using Resume.Domain.Models.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IMenuGroupsService
    {
        Task<IEnumerable<MenuGroup>> GetAllAsync();
        Task<MenuGroup?> GetByIdAsync(int id);
        Task<MenuGroup> AddAsync(MenuGroup group);
        Task<MenuGroup> UpdateAsync(MenuGroup group);
        Task<bool> DeleteAsync(int id);
    }
}
