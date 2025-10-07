using Resume.Maui.Data.PageModels;
using Resume.Maui.ViewModels.BaseViews;

namespace Resume.Maui.Services.Interfaces
{
    public interface INavigationService
    {
        public Task NavigateToAsync<TViewModel>(params object[] arguments);

        public Task NavigateToExampleAsync(Sample example, bool popToMain = false, bool? animated = null);

        public Task NavigateToConfigurationPageAsync(SampleViewModel viewmodel);

        //public Task NavigateToDescriptionPageAsync(DescriptionViewModel viewmodel);

        //public Task NavigateToSettingsPageAsync(SettingsViewModel viewmodel);

        //public Task NavigateToThemeSettingsPageAsync(ThemeSettingsViewModel viewmodel);

        public Task NavigateToRootAsync();

        public Task NavigateBackAsync();

        public Task NavigateCommand(string cmd);
    }
}
