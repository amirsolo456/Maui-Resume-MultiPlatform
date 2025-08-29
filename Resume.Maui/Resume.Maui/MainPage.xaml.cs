using Resume.Maui.Shared.ViewModels;

namespace Resume.Maui
{
    public partial class MainPage : ContentPage
    {
        MainpageViewmodel _mainpageViewmodel;
        public MainPage()
        {
            InitializeComponent();
            _mainpageViewmodel = new MainpageViewmodel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (ThemeManager.SelectedTheme != nameof(Resume.Maui.Resources.Themes.Dark))
                {
                    ThemeManager.SetTheme(nameof(Resume.Maui.Resources.Themes.Dark));
                }
                else
                {
                    ThemeManager.SetTheme(nameof(Resume.Maui.Resources.Themes.Light));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("خطا" + ex.Message);
            }
        }
    }
}
