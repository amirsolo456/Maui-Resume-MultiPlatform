using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Resume.Infrastructure.DBContext
{
    public class ResumeDbContextFactory : IDesignTimeDbContextFactory<ResumeDbContext>
    {
        public ResumeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ResumeDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ResumeDb;Integrated Security=True");

            return new ResumeDbContext(optionsBuilder.Options);
        }
    }
}
