using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Resume.Infrastructure.Data.DBContext
{
    public class ResumeDbContextFactory : IDesignTimeDbContextFactory<ResumeDbContext>
    {
        public ResumeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ResumeDbContext>();
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ResumeDb;Integrated Security=True");
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ResumeDb;Integrated Security=True;Trust Server Certificate=True");

            return new ResumeDbContext(optionsBuilder.Options);
        }
    }
}
