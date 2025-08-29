using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models
{
    public class Education
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(150)]
        public string School { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Degree { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string FieldOfStudy { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
 

        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
        public Guid? NavigationItemId { get; set; } // ← nullable
        public NavigationItem? NavigationItem { get; set; }
    }

}
