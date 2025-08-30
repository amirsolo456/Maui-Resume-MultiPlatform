using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resume.Application.Interfaces;
using Resume.Infrastructure.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Infrastructure.Services
{
    public class InfrastructureModule : Application.Interfaces.IModule
    {
        public void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResumeDbContext>(options =>
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ResumeDb;Integrated Security=True"));

            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProjectService, ProjectService>();

            services.AddScoped<IResumeDbContext>(provider =>
    provider.GetRequiredService<Resume.Infrastructure.Data.ResumeDbContext>());
        }
    }
}
