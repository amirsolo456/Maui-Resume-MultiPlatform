using Resume.Maui.Resources.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Shared.Resources.Theme
{
    public static class ThemeColorManager 
    {
        private static ResourceDictionary _lightTheme = new Light();
        private static ResourceDictionary _darkTheme = new Dark();
        public static AppTheme CurrentTheme { get; private set; } = Application.Current.RequestedTheme;

        public static void SetTheme(AppTheme theme)
        { 
            var appResources = Application.Current.Resources;
            appResources.MergedDictionaries.Clear();
            switch (theme)
            {
                case AppTheme.Light:
                    appResources.MergedDictionaries.Add(_lightTheme);
                    CurrentTheme = AppTheme.Light;
                    break;

                case AppTheme.Dark:
                    appResources.MergedDictionaries.Add(_darkTheme);
                    CurrentTheme = AppTheme.Dark;
                    break;
            }
        }

        public static void ToggleTheme()
        {
            if (CurrentTheme == AppTheme.Light)
                SetTheme(AppTheme.Dark);
            else
                SetTheme(AppTheme.Light);
        }
    }
}
