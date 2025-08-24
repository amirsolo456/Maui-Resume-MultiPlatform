namespace Resume.Maui.Shared.Controls;

public partial class ImageFrameCircle : Frame
{

    // BindableProperty برای ImageSource
    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(
            nameof(ImageSource),
            typeof(ImageSource),
            typeof(ImageFrameCircle),
            default(ImageSource));

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    public ImageFrameCircle()
    {
        WidthRequest = 120;
        HeightRequest = 120;
        CornerRadius = 60;
        IsClippedToBounds = true;
        BorderColor = Colors.Gray;
        Padding = 0;

        var image = new Image
        {
            Aspect = Aspect.AspectFill
        };
        image.SetBinding(Image.SourceProperty, new Binding(nameof(ImageSource), source: this));

        Content = image;

        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += async (s, e) =>
        {
            var grid = new Grid
            {
                BackgroundColor = Colors.Black
            };

            var image = new Image
            {
                Source = ImageSource,
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            grid.Children.Add(image);

            // Gesture روی Grid، نه ContentPage
            grid.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await Application.Current.MainPage.Navigation.PopModalAsync())
            });

            var viewerPage = new ContentPage
            {
                Content = grid
            };

            await Application.Current.MainPage.Navigation.PushModalAsync(viewerPage);
        };


        this.GestureRecognizers.Add(tapGesture);
    }

}

