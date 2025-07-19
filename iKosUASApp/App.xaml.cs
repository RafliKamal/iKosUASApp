using iKosUASApp.Pages;
using iKosUASApp.Service;

namespace iKosUASApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        DataService.LoadData(); 

        string username = Preferences.Default.Get("LoggedInUser", "");
        MainPage = new NavigationPage(string.IsNullOrEmpty(username) ? new SplashPage() : new MainNavigationPage());

        Microsoft.Maui.Handlers.PageHandler.Mapper.AppendToMapping("SafeArea", (handler, view) =>
        {
#if ANDROID
    handler.PlatformView.SetFitsSystemWindows(false);
#endif
        });
    }

    protected override void OnStart()
    {
        DataService.LoadData();
    }

    protected override void OnSleep()
    {
        DataService.SaveData();
    }

    protected override void OnResume()
    {
        DataService.LoadData();
    }
}