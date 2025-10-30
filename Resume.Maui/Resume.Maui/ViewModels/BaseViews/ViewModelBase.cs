using Resume.Maui.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Maui.Controls;

namespace Resume.Maui.ViewModels.BaseViews
{
    public class ViewModelBase : NotifyPropertyChangedBase
    {
        public INavigationService NavigationService => DependencyService.Get<INavigationService>();
    }
}
