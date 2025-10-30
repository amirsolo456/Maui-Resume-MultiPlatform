namespace Resume.Maui.iOS
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
