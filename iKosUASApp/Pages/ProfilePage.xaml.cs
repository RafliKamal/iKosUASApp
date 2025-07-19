using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();

        if (AuthService.CurrentUser != null)
        {
            usernameLabel.Text = $"Halo, {AuthService.CurrentUser.Username}";
        }
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        AuthService.Logout();
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
}