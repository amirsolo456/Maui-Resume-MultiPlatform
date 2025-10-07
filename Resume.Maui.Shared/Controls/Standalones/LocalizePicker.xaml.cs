using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Resume.Maui.Shared.Controls.Standalones;

public partial class LocalizePicker : ContentView,INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string name = "") =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    public LocalizePicker()
	{
		InitializeComponent();
	}
    private string _currentTheme;
    public string CurrentTheme
    {
        get => _currentTheme;
        set
        {
            if (_currentTheme != value)
            {
                _currentTheme = value;
                OnPropertyChanged(); // reports this property
            }
        }
    }
    private ObservableCollection<string> _localizeItems;
    public ObservableCollection<string> LocalizeItems
    {
        get => _localizeItems;
        set
        {
            if (_localizeItems != value)
            {
                _localizeItems = value;
                OnPropertyChanged(); // reports this property
            }
        }
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        comboBox.IsDropDownOpen = true;
    }
}