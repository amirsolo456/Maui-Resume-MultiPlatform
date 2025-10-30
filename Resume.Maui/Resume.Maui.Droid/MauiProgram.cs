using CommunityToolkit.Maui.Core;

namespace Resume.Maui.Droid
{
    public static class MauiProgram
    {
        public static Microsoft.Maui.Hosting.MauiApp CreateMauiApp()
        {
            var builder = Microsoft.Maui.Hosting.MauiApp.CreateBuilder();

            builder
                .UseSharedMauiApp();

            return builder.Build();
        }
    }
}
