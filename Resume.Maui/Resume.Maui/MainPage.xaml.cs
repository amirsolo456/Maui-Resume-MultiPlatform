namespace Resume.Maui
{
    public partial class MainPage : ContentPage
    {
        //protected  Dictionary<int,string> Sources =new Dictionary<int, string>() { { 1, "Change Theme"} };
        public MainPage()
        {
            InitializeComponent();
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
