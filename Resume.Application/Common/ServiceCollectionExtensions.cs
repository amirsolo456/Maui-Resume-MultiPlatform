using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resume.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Common;
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// اسمبلی‌های ورودی را اسکن می‌کند، هر کلاسی که IModule یا IInfrastructureModule باشد را می‌سازد و Register را صدا می‌زند.
    /// </summary>
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
    {
        var moduleType = typeof(IModule); // یا IInfrastructureModule

        var modules = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && moduleType.IsAssignableFrom(t))
            .Select(t => (IModule)Activator.CreateInstance(t)!);

        foreach (var module in modules)
            module.Register(services, configuration);
    }

    /// <summary>
    /// نسخه راحت برای Load از اسم اسمبلی
    /// </summary>
    public static void RegisterModulesByName(this IServiceCollection services, IConfiguration configuration, params string[] assemblyNames)
    {
        var assemblies = assemblyNames.Select(Assembly.Load).ToArray();
        services.RegisterModules(configuration, assemblies);
    }
}

