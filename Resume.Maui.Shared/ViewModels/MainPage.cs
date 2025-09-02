using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using Resume.Maui.Shared.Core.Entities.MenuItems;
using Resume.Maui.Shared.Services.Api;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Maui.Shared.ViewModels;

public partial class MainPage : ObservableObject
{
    [ObservableProperty]
    private IEnumerable<ResponseData> _itemsResponse;
    protected readonly NavigationItemsService<Core.Entities.MenuItems.Response, Core.Entities.MenuItems.Request> _navigationItemsService;
    public MainPage(NavigationItemsService<Core.Entities.MenuItems.Response, Core.Entities.MenuItems.Request> navigationItems)
    {
        _navigationItemsService = navigationItems;
    }

    public async void PrepareDatas(int ID)
    {
        var dt = await GetItemsByPerson(ID);

        if (dt != null)
        {
            ItemsResponse =new ObservableCollection<ResponseData>(dt.Data.ToObservableCollection());
        }
    }

    private async Task<Response> GetItemsByPerson(int ID)
    {
        Response response = new();
        try
        {
            response = await _navigationItemsService.GetNavItemsAsync(ID);
        }
        catch (Exception ex)
        {

        }
        return response;
    }
}

