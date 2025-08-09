using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Core.Models
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Summary { get; set; } = "";

        public List<WorkExperience> WorkExperiences { get; set; } = new();
        public List<Education> Educations { get; set; } = new();
        public List<Skill> Skills { get; set; } = new();
        public List<Project> Projects { get; set; } = new();
    }
}
