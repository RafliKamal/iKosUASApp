using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (AuthService.Register(usernameEntry.Text, passwordEntry.Text))
        {
            await DisplayAlert("Sukses", "Registrasi berhasil", "OK");
            await Navigation.PushAsync(new LoginPage());
        }
        else
        {
            await DisplayAlert("Gagal", "Username sudah digunakan", "OK");
        }
    }

    private async void OnGoToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}
