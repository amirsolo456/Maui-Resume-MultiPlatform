using Resume.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Core.Models
{
    public class Skill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 10)]
        public int Level { get; set; }
        public string Category { get; set; } = null!;

        public Guid? NavigationItemId { get; set; } // ← nullable
        public NavigationItem? NavigationItem { get; set; }
        public Guid? PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
