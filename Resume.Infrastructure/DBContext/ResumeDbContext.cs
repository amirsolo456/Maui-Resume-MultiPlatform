using Microsoft.EntityFrameworkCore;
using Resume.Core.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ResumeDbContext : DbContext
{ 
    public ResumeDbContext(DbContextOptions<ResumeDbContext> options) : base(options) { }

    public DbSet<Person> Persons => Set<Person>();
    public DbSet<WorkExperience> WorkExperiences => Set<WorkExperience>();
    public DbSet<Education> Educations => Set<Education>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Project> Projects => Set<Project>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }
}
