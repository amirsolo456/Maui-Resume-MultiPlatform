using Resume.Maui.Shared.Core.Entities.MenuItems;
using Resume.Maui.Shared.ViewModels;
using System.Threading.Tasks;

namespace Resume.Maui
{
    public partial class MainPage : ContentPage
    {
        MainpageViewmodel _mainpageViewmodel;
        public MainPage(MainpageViewmodel mainpage)
        {
            InitializeComponent();
            _mainpageViewmodel = mainpage;
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            _mainpageViewmodel.PrepareDatas(1);
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
