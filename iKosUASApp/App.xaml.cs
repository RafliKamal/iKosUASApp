using iKosUASApp.Pages;

namespace iKosUASApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        string username = Preferences.Default.Get("LoggedInUser", "");
        MainPage = new NavigationPage(string.IsNullOrEmpty(username) ? new SplashPage() : new MainNavigationPage());
    }
}