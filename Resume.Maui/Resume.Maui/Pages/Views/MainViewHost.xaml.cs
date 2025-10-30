namespace Resume.Maui.Pages.Views;

public partial class MainViewHost : ContentView
{
    private View? _currentView;

    /// <summary>
    /// ویو جدید را فقط در لحظه نمایش می‌دهد
    /// </summary>
    /// <param name="view">View برای نمایش</param>
    public void SetView(View view)
    {
        if (_currentView != null)
        {
            this.Content = null;
            _currentView = null;
        }

        if (view != null)
        {
            _currentView = view;
            this.Content = _currentView;
        }
    }

    /// <summary>
    /// ویو فعلی
    /// </summary>
    public View? GetCurrentView() => _currentView;
    public MainViewHost()
	{
		InitializeComponent();
	}
}