using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resume.Application.Dtos;

public class MenuItemType
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public int ForeignId { get; set; }
    public ICollection<MainMenus> MainMenus { get; set; }
}
