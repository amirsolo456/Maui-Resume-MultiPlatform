using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Core.Models
{
    public class WorkExperience
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Company { get; set; } = "";
        public string Position { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; } = "";

        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
