using Resume.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Core.Models
{
    public class Project
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Url { get; set; } = string.Empty;

        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
        public Guid? NavigationItemId { get; set; } // ← nullable
        public NavigationItem? NavigationItem { get; set; }
    }   
}
