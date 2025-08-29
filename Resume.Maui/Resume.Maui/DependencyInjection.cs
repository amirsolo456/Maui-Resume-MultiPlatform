using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Resume.Maui.Shared.Core.Entities.MenuItems;
using Resume.Maui.Shared.Services.Api;
 
namespace Resume.Maui;

public static class DependencyInjection
{
    public static MauiAppBuilder RegisterApiServices(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient(typeof(INavigationItemsService<,>), typeof(NavigationItemsService<,>));
        builder.Services.AddSingleton<IApiClient, ApiClient>();
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
