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
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(themeToBeApplied);
            SelectedTheme = ThemeName;
        }
    }
}
