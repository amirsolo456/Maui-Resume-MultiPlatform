using Foundation;

namespace Resume.Maui.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override Microsoft.Maui.Hosting.MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
