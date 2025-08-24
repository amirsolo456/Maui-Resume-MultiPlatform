using Microsoft.Maui.Controls;
using Resume.Maui.Resources.Themes;

namespace Resume.Maui
{
    public static class ThemeManager
    {
        private static IDictionary<string, ResourceDictionary> _themesMap =
            new Dictionary<string, ResourceDictionary>
            {
                [nameof(Default)] =new Default(),
                [nameof(Light)] =new Light(),
                [nameof(Dark)] =new Dark(),
            };

        public static string SelectedTheme { get; set; } = nameof(Default);
        public static void SetTheme(string ThemeName)
        {
            if (SelectedTheme == ThemeName) return;

            var themeToBeApplied = _themesMap[ThemeName];
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                mergedDictionaries.Add(themeToBeApplied);
            }

            //Application.Current.Resources.MergedDictionaries.Remove(_themesMap[SelectedTheme]);
            //Application.Current.Resources.MergedDictionaries.Add(themeToBeApplied);
            SelectedTheme = ThemeName;

            try
            {
                AppTheme currentTheme = Application.Current.RequestedTheme;
                currentTheme= ((SelectedTheme != nameof(Resume.Maui.Resources.Themes.Light)) ? AppTheme.Dark : AppTheme.Light);

                Application.Current.UserAppTheme = ((SelectedTheme != nameof(Resume.Maui.Resources.Themes.Light)) ? AppTheme.Dark : AppTheme.Light);
 
            }
            catch (Exception)
            {
 
            }
        }
    }
}
