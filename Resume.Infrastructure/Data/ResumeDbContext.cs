using Microsoft.EntityFrameworkCore;
using Resume.Application.Interfaces;
using Resume.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Data
{
    public class ResumeDbContext : DbContext, IResumeDbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options)
        : base(options) { }
        public DbSet<Education> Educations => Set<Education>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Contact> Contacts => Set<Contact>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // اگر میخوای Configuration از Assembly بیاره:
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResumeDbContext).Assembly);
        }
    }
}
