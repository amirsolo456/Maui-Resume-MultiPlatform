using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Dtos.MainMenusDto
{
    public class MenuItemTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ForeignId { get; set; }
        public ICollection<MainMenus> MainMenus { get; set; }
    }
}
