using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resume.Application.Interfaces;
using Resume.Infrastructure.Data.DBContext;
using Resume.Infrastructure.Services;

namespace Resume.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("CleanArchitectureDb");
            builder.Services.AddDbContext<IResumeDbContext, Resume.Infrastructure.Data.ResumeDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ResumeDb"));
            });

       
            builder.Services.AddScoped<IEducationService, EducationService>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IResumeDbContext>(provider => provider.GetRequiredService<Resume.Infrastructure.Data.ResumeDbContext>());

        }
    }
}
