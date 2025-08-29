using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Telerik.Maui.Controls.Compatibility;

namespace Resume.Maui
{
    public static class MauiProgramExtensions
    {
        public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
        {
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseTelerik()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("IRANSansX-Bold.ttf", "IRANSansX");
                    fonts.AddFont("IRANSansX-Regular.ttf", "IRANSans");
                    fonts.AddFont("Yekan.ttf", "Yekan");
                });

            builder.RegisterApiServices();
            builder.RegisterViews();
            builder.RegisterViewModels();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder;
        }
    }
}
