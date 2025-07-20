using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (AuthService.Login(usernameEntry.Text, passwordEntry.Text))
        {
            await Task.Delay(150); // jeda kecil agar terasa halus
            Application.Current.MainPage = new NavigationPage(new MainNavigationPage());
        }
        else
        {
            await DisplayAlert("Login Gagal", "Username atau password salah.", "OK");
        }
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }


    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }
}