using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Resume.Infrastructure.Data.DBContext
{

    // -- 1. تغییر دیتابیس به حالت SINGLE_USER تا هیچ کانکشنی نداشته باشه
    //ALTER DATABASE[ResumeDb]
    //SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

    //-- 2. تغییر Collation دیتابیس به فارسی
    //ALTER DATABASE[ResumeDb]
    //COLLATE Persian_100_CI_AS;

    //-- 3. بازگرداندن دیتابیس به حالت MULTI_USER
    //ALTER DATABASE[ResumeDb]
    //SET MULTI_USER;

    public class ResumeDbContext : DbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options) { }

        #region DbSets
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<WorkExperience> WorkExperiences => Set<WorkExperience>();
        public DbSet<Education> Educations => Set<Education>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<NavigationItem> NavigationItems => Set<NavigationItem>();
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region NavigationItem Config
            modelBuilder.Entity<NavigationItem>()
                        .HasIndex(n => n.KeyName)
                        .IsUnique();
            #endregion

            #region Person Relationships
            modelBuilder.Entity<Person>()
                .HasMany(p => p.WorkExperiences)
                .WithOne(w => w.Person)
                .HasForeignKey(w => w.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Educations)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Skills)
                .WithOne(s => s.Person)
                .HasForeignKey(s => s.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Projects)
                .WithOne(pr => pr.Person)
                .HasForeignKey(pr => pr.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Contacts)
                .WithOne(c => c.Person)
                .HasForeignKey(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region NavigationItem Relationships
            modelBuilder.Entity<Skill>()
                .HasOne(s => s.NavigationItem)
                .WithMany(n => n.Skills)
                .HasForeignKey(s => s.NavigationItemId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<WorkExperience>()
                .HasOne(w => w.NavigationItem)
                .WithMany(n => n.Experiences)
                .HasForeignKey(w => w.NavigationItemId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Education>()
                .HasOne(e => e.NavigationItem)
                .WithMany(n => n.Educations)
                .HasForeignKey(e => e.NavigationItemId)
                .OnDelete(DeleteBehavior.Restrict); // یا Cascade


            modelBuilder.Entity<Project>()
                .HasOne(pr => pr.NavigationItem)
                .WithMany(n => n.Projects)
                .HasForeignKey(pr => pr.NavigationItemId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.NavigationItem)
                .WithMany(n => n.Contacts)
                .HasForeignKey(c => c.NavigationItemId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion
        }
    }
}
