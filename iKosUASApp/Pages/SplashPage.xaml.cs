namespace iKosUASApp.Pages;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
        Splash();
    }

    private async void Splash()
    {
        await Task.Delay(1500);
        await Navigation.PushAsync(new RegisterPage());
    }
}