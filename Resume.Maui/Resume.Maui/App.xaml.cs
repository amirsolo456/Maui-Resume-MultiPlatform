using Microsoft.Maui.Controls.PlatformConfiguration;
using Resume.Maui.Pages.Mobile;
using Resume.Maui.Pages.Views;
using Resume.Maui.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Resume.Maui
{
    public partial class App : Application
    {
        public App(IConfigurationService configurationService, INavigationService navigationService)
        {
            InitializeComponent();

            // تم اولیه
            this.UserAppTheme = Microsoft.Maui.ApplicationModel.AppTheme.Light;

            // ست کردن MainPage بر اساس دیوایس
            if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
            {
                // بعداً برای دسکتاپ می‌تونی MainPageDesktop بسازی
                MainPage = new NavigationPage(new MainPageMobile())
                {
                    BarBackgroundColor = Colors.White,
                    BarTextColor = Colors.Black
                };
            }
            else
            {
                // موبایل
                MainPage = new NavigationPage(new MainPageMobile())
                {
                    BarBackgroundColor = Colors.White,
                    BarTextColor = Colors.Black
                };
            }
        }

        public static void DisplayAlert(string text)
        {
            var popup = new Telerik.Maui.Controls.RadPopup
            {
                IsModal = true,
                Placement = Telerik.Maui.Controls.PlacementMode.Center,
                OutsideBackgroundColor = Color.FromArgb("#6F000000")
            };

            var border = new Telerik.Maui.Controls.RadBorder
            {
                CornerRadius = new  Thickness(8,8,8,8),
                BackgroundColor = Color.FromArgb("#F1F1F1")
            };

            var grid = new Grid
            {
                Padding = new Thickness(10),
                WidthRequest = 200,
                HeightRequest = 150,
                RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Star },
                new RowDefinition { Height = 30 }
            }
            };

            var label = new Label
            {
                Text = text,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Colors.Black,
                LineBreakMode = LineBreakMode.WordWrap
            };
            Grid.SetRow(label, 0);
            grid.Children.Add(label);

            var okButton = new Telerik.Maui.Controls.RadButton
            {
                Padding = new Thickness(2),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End,
                BackgroundColor = Color.FromArgb("#674bb2"),
                TextColor = Colors.White,
                Text = "OK"
            };
            okButton.Clicked += (s, e) => popup.IsOpen = false;
            Grid.SetRow(okButton, 1);
            grid.Children.Add(okButton);

            border.Content = grid;
            popup.Content = border;
            popup.IsOpen = true;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
