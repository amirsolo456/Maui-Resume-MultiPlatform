using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Resume.Maui.Shared.Core.Entities.MenuItems;
using Resume.Maui.Shared.Services.Api;
using System.Collections.ObjectModel;

namespace Resume.Maui.Shared.ViewModels;

public partial class MainPage : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ResponseData> _itemsResponse;

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private string _errorMessage;

    [ObservableProperty]
    private View _currentContent;

    private readonly INavigationItemsService<Core.Entities.MenuItems.Response, Core.Entities.MenuItems.Request> _navigationItemsService;

    public MainPage(INavigationItemsService<Core.Entities.MenuItems.Response, Core.Entities.MenuItems.Request> navigationItems)
    {
        _navigationItemsService = navigationItems;
        RefreshCommand = new RelayCommand<int>(async (id) => await PrepareDatas(id));
    }

    [RelayCommand]
    private async Task PrepareDatas(int ID)
    {
        try
        {
            IsLoading = true;
            ErrorMessage = string.Empty;

            var response = await _navigationItemsService.GetNavItemsAsync(ID);

            if (response?.Data != null)
            {
                ItemsResponse = new ObservableCollection<ResponseData>(response.Data);
            }
            else
            {
                ItemsResponse = new ObservableCollection<ResponseData>();
                ErrorMessage = "No navigation items found";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Error loading navigation items: {ex.Message}";
            ItemsResponse = new ObservableCollection<ResponseData>();

            // لاگ کردن خطا برای دیباگ
            Console.WriteLine($"Error in PrepareDatas: {ex}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    public IRelayCommand<int> RefreshCommand { get; }
}