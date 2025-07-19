using iKosUASApp.Model;

namespace iKosUASApp.Service;

public static class AuthService
{
    public static List<User> Users { get; set; } = new();
    public static User? CurrentUser;

    public static bool Register(string username, string password)
    {
        if (Users.Any(u => u.Username == username)) return false;
        var newUser = new User { Username = username, Password = password };
        Users.Add(newUser);
        Save();
        return true;
    }

    public static bool Login(string username, string password)
    {
        var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            CurrentUser = user;
            Preferences.Default.Set("LoggedInUser", username);
            return true;
        }
        return false;
    }

    public static void Logout()
    {
        Preferences.Default.Remove("LoggedInUser");
        CurrentUser = null;
    }

    public static void Save()
    {
        DataService.SaveData();
    }
}