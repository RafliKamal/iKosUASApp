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
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;
        string kosName = kosNameEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(kosName))
        {
            await DisplayAlert("Gagal", "Semua field wajib diisi", "OK");
            return;
        }

        if (AuthService.Register(username, password, kosName))
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
