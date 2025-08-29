using CommunityToolkit.Mvvm.ComponentModel;
using Resume.Maui.Shared.Core.Entities.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Shared.ViewModels;

public partial class MainPage : ObservableObject
{
    [ObservableProperty]
    private IEnumerable<ResponseData> _itemsResponse;

    public MainPage()
    {

    }
}

