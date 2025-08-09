using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Resume.Infrastructure.DBContext
{
    public class ResumeDbContextFactory : IDesignTimeDbContextFactory<ResumeDbContext>
    {
        public ResumeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ResumeDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=ResumeDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new ResumeDbContext(optionsBuilder.Options);
        }
    }
}
