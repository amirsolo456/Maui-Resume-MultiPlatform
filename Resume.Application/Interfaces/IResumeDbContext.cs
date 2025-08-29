using Microsoft.EntityFrameworkCore;
using Resume.Domain.Models;

namespace Resume.Application.Interfaces;

public interface IResumeDbContext
{
    DbSet<Education> Educations { get; }
    DbSet<Person> Persons { get; }
    DbSet<Project> Projects { get; }
    DbSet<Contact> Contacts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
