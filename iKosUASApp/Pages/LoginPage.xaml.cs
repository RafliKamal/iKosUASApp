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
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Login Gagal", "Username dan password tidak boleh kosong.", "OK");
            return;
        }

        if (AuthService.Login(username, password))
        {
            await Task.Delay(150);
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

}
