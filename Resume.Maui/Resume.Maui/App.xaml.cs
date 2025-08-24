namespace Resume.Maui
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();
                Application.Current.UserAppTheme = AppTheme.Unspecified;
                var b = AppInfo.Current.RequestedTheme;
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطا:"+ex.Message);

            }       
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
