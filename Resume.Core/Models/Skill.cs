using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Core.Models
{
    public class Skill
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public int Level { get; set; } // مثلا 1 تا 10

        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
