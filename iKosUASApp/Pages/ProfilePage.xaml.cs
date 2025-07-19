using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();

        var user = AuthService.CurrentUser;
        if (user != null)
        {
            usernameLabel.Text = $"Halo, {user.Username}";
            kosNameLabel.Text = user.KosName;

            if (!string.IsNullOrEmpty(user.ProfileImagePath))
            {
                profileImage.Source = ImageSource.FromFile(user.ProfileImagePath);
            }
        }
    }

    private async void OnEditProfileClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditProfilePage());
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var user = AuthService.CurrentUser;
        if (user != null)
        {
            usernameLabel.Text = $"Halo, {user.Username}";
            kosNameLabel.Text = user.KosName;

            if (!string.IsNullOrEmpty(user.ProfileImagePath))
            {
                profileImage.Source = ImageSource.FromFile(user.ProfileImagePath);
            }
            else
            {
                profileImage.Source = null;
            }
        }
    }


    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        AuthService.Logout();
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
}
