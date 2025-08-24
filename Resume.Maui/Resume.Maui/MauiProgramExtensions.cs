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
                .UseTelerik()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("IRANSansX-Bold.ttf", "IRANSansX");
                    fonts.AddFont("IRANSansX-Regular.ttf", "IRANSans");
                    fonts.AddFont("Yekan.ttf", "Yekan");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder;
        }
    }
}
