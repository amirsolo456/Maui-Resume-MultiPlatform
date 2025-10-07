using Resume.Application.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models.MainMenu;

[Table("MenuGroups")]
public class MenuGroup
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    public ICollection<MainMenus> Menus { get; set; }
}
