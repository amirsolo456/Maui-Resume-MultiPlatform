using Microsoft.EntityFrameworkCore;
using Resume.Application.Dtos;
using Resume.Application.Interfaces;
using Resume.Infrastructure.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services
{
    public class MainMenusService : IMainMenuService
    {
        private readonly ResumeDbContext _context;

        public MainMenusService(ResumeDbContext context)
        {
            _context = context;
        }

        public Task<MainMenus> CreateAsync(MainMenus item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Menus.FindAsync(id);
            if (item != null)
            {
                _context.Menus.Remove(item);
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(MainMenus item)
        {
            _context.Menus.Remove(item);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(IEnumerable<MainMenus> item)
        {
            _context.Menus.RemoveRange(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MainMenus>> GetAllAsync()
        {
            return await _context.Menus
                .Include(m => m.Children)
                .Include(m => m.Parent)
                .Include(m => m.MenuGroup)  // اگر بخوای گروه منو هم لود بشه
                .Include(m => m.Type)       // MenuItemType
                .ToListAsync();
        }

        public async Task<MainMenus?> GetByIdAsync(int id)
        {
            return await _context.Menus
                .Include(m => m.Children)
                .Include(m => m.Parent)
                .Include(m => m.MenuGroup)
                .Include(m => m.Type)
                .FirstOrDefaultAsync(m => m.Id == Convert.ToInt32(id));
        }


        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task UpdateAsync(MainMenus item)
        {
            _context.Menus.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}
