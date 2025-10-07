using Resume.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Domain.Models
{

    public class Person
    {
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string? DisplayName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string? Username { get; set; } = string.Empty;

        [Required, MaxLength(200), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MaxLength(20), Phone]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Summary { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Password stored securely
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string PasswordSalt { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<UserToken> Tokens { get; set; } = new List<UserToken>();

    }
}
