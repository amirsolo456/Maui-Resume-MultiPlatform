using Resume.Maui.Data.PageModels;
using Resume.Maui.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Resume.Maui.ViewModels.BaseViews
{
    //[DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(MainViewHostViewModel))]
    public class MainViewHostViewModel : PageViewModel
    {
        private Control selectedControl;
        private bool isHomeSelected;
        private bool isSearchSelected;
        private bool isSettingsSelected;
        //private HighlightedSearchResult selectedSearchResult;
        public MainViewHostViewModel()
        {
            IConfigurationService configurationService = DependencyService.Get<IConfigurationService>();
            Configuration configuration = configurationService.Configuration;
            this.HighlightControls = GetHighlightControls(configuration);
        }
        public ObservableCollection<Control> Controls { get; }

        public ObservableCollection<HighlightedControl> HighlightControls { get; }

        public ObservableCollection<Sample> Samples { get; }

        public ObservableCollection<MauiHighlight> MauiHighlights { get; }

        //public ObservableCollection<DemoApp> DemoApps { get; }

        public ICommand SelectHomeCommand { get; }

        public ICommand SelectControlCommand { get; }

        public ICommand SelectDemoAppCommand { get; }

        public ICommand SelectMauiHighlightCommand { get; }

        public ICommand SelectSearchCommand { get; }

        public ICommand SelectSettingsCommand { get; }

        public ICommand LinkTapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public Control SelectedControl
        {
            get
            {
                return this.selectedControl;
            }
            set
            {
                this.UpdateValue(ref this.selectedControl, value);
            }
        }

        public bool IsHomeSelected
        {
            get
            {
                return this.isHomeSelected;
            }
            set
            {
                if (this.UpdateValue(ref this.isHomeSelected, value))
                {
                    //this.OnIsHomeSelectedChanged();
                }
            }
        }

        public bool IsSearchSelected
        {
            get
            {
                return this.isSearchSelected;
            }
            set
            {
                if (this.UpdateValue(ref this.isSearchSelected, value))
                {
                   // this.OnIsSearchSelectedChanged();
                }
            }
        }

        public bool IsSettingsSelected
        {
            get
            {
                return this.isSettingsSelected;
            }
            set
            {
                if (this.UpdateValue(ref this.isSettingsSelected, value))
                {
                  //  this.OnIsSettingsSelectedChanged();
                }
            }
        }
        private static ObservableCollection<Control> GetControls(IEnumerable<Control> configuration)
        {
            ObservableCollection<Control> result = new ObservableCollection<Control>(configuration);
            return result;
        }
        public void NavigateToSettings()
        {
            //this.NavigationService.NavigateToSettingsPageAsync(new SettingsViewModel());
        }

        private static ObservableCollection<HighlightedControl> GetHighlightControls(Configuration configuration)
        {
            ObservableCollection<HighlightedControl> result = new ObservableCollection<HighlightedControl>();

            foreach (HighlightedControl highlighted in configuration.HighlightedControls)
            {
                result.Add(highlighted);

                Control control = configuration.Controls.FirstOrDefault(c => object.Equals(highlighted.DisplayName, c.DisplayName));
                if (control == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(highlighted.ShortDescription))
                {
                    highlighted.ShortDescription = control.ShortDescription;
                }

                if (string.IsNullOrEmpty(highlighted.Icon))
                {
                    highlighted.Icon = control.Icon;
                }
            }

            return result;
        }
        private void SelectHome()
        {
            this.IsHomeSelected = true;
        }
    }

}
