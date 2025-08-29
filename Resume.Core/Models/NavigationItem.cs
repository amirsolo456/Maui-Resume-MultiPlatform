using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models;
 
 
    public class NavigationItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    [Required, MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Icon { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string KeyName { get; set; } = string.Empty;

    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<WorkExperience> Experiences { get; set; } = new List<WorkExperience>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        //public ICollection<NavigationItem> NavigationItems { get; set; } = new List<NavigationItem>();
    }
 

