using Resume.Domain.Models.MainMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Dtos.MainMenusDto
{
    public class MainMenus
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string? TargetPage { get; set; }
        [Required]
        [ForeignKey(nameof(MenuItemTypeId))]
        public MenuItemType Type { get; set; }
        [Required]
        public int MenuItemTypeId { get; set; }   // 🔹 کلید خارجی
        [MaxLength(250)]
        public string? ImageSource { get; set; }

        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public MainMenus? Parent { get; set; }

        [InverseProperty(nameof(Parent))]
        public ICollection<MainMenus>? Children { get; set; }

        [Required]
        public int MenuGroupId { get; set; }

        [ForeignKey(nameof(MenuGroupId))]
        public MenuGroup MenuGroup { get; set; }
    }
}
