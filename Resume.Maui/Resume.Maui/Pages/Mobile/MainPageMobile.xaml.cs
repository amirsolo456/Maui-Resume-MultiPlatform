using Resume.Maui.ViewModels.BaseViews;

namespace Resume.Maui.Pages.Mobile;

public partial class MainPageMobile : ContentPage
{
	public MainPageMobile()
	{
      
        this.BindingContext = new MainViewHostViewModel();
        this.InitializeComponent();

        this.Loaded += this.OnLoaded;
    }

    private void OnLoaded(object sender, EventArgs args)
    {
        this.Loaded -= OnLoaded;

 
//            MainViewHostViewModel vm = (MainViewHostViewModel)this.BindingContext;
//#if IOS
//            // TRICKY: Pushing a non-animated page on startup will screw up the page navigation in iOS.
//            vm.NavigationService.NavigateToExampleAsync(vm.Examples[0], animated: true);
//#else
//            vm.NavigationService.NavigateToExampleAsync(vm.Samples[0], animated: false);
//#endif
      
    }

    private void Settings_Clicked(object sender, EventArgs e)
    {
        MainViewHostViewModel vm = (MainViewHostViewModel)this.BindingContext;
        vm.NavigateToSettings();
    }

    private void Search_Clicked(object sender, EventArgs e)
    {
        MainViewHostViewModel vm = (MainViewHostViewModel)this.BindingContext;
        vm.NavigateToSettings();
    }

    private void controlsCollectionView_ItemTapped(object sender, Telerik.Maui.RadTappedEventArgs<object> e)
    {
        MainViewHostViewModel vm = (MainViewHostViewModel)this.BindingContext;
        vm?.SelectControlCommand?.Execute(e.Data);
    }
}