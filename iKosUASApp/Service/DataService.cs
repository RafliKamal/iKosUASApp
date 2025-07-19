using iKosUASApp.Model;
using System.Text.Json;

namespace iKosUASApp.Service;

public static class DataService
{
    private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "users.json");

    public static void SaveData()
    {
        try
        {
            var json = JsonSerializer.Serialize(AuthService.Users);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gagal menyimpan data: {ex.Message}");
        }
    }

    public static void LoadData()
    {
        try
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var users = JsonSerializer.Deserialize<List<User>>(json);
                if (users != null) AuthService.Users = users;

                string savedUsername = Preferences.Default.Get("LoggedInUser", "");
                AuthService.CurrentUser = users?.FirstOrDefault(u => u.Username == savedUsername);

             
                if (AuthService.CurrentUser != null)
                {
                    foreach (var room in AuthService.CurrentUser.Rooms)
                    {
                        if (room.Tenant != null)
                        {
                            room.Tenant.Room = room;

                            
                            room.Tenant.Payments = new System.Collections.ObjectModel.ObservableCollection<Payment>(room.Tenant.Payments);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gagal memuat data: {ex.Message}");
        }
    }

}
