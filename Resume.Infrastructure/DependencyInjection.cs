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
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            services.AddDbContext<IResumeDbContext, Resume.Infrastructure.Data.ResumeDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ResumeDb"));
            });

            // Services
            //services.AddScoped<IEducationService, EducationService>();
            //services.AddScoped<IPersonService, PersonService>();
            //services.AddScoped<IProjectService, ProjectService>();

            // رجیستر DbContext به صورت Interface
            services.AddScoped<IResumeDbContext>(provider =>
                provider.GetRequiredService<Resume.Infrastructure.Data.ResumeDbContext>());

            return services;
        }
    }
}
