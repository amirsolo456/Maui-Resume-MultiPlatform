using Microsoft.Extensions.Hosting;
using Resume.Maui.Pages;
using Resume.Maui.Services.Interfaces;
using Resume.Maui.Shared.Core.Entities.MenuItems;
using Resume.Maui.Shared.Services.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Resume.Maui;

public static class DependencyInjection
{
    public static MauiAppBuilder RegisterApiServices(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient(typeof(INavigationItemsService<,>), typeof(NavigationItemsService<,>));
        builder.Services.AddSingleton<IApiClient, ApiClient>();
        builder.Services.AddSingleton<IConfigurationService, configurations>();
        return builder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainPage>();
        return builder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainpageViewmodel>();
        return builder;
    }
}
