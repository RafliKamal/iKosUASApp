using iKosUASApp.Model;
using System.Collections.ObjectModel;

namespace iKosUASApp.Service;

public static class RoomService
{
    public static ObservableCollection<Room> GetRooms()
        => AuthService.CurrentUser?.Rooms ?? new ObservableCollection<Room>();

    public static void AddRoom(Room room)
    {
        AuthService.CurrentUser?.Rooms.Add(room);
        DataService.SaveData();
    }

    public static void RemoveRoom(Room room)
    {
        AuthService.CurrentUser?.Rooms.Remove(room);
        DataService.SaveData();
    }
    public static void UpdateRoom(Room updatedRoom)
    {
        var existing = AuthService.CurrentUser?.Rooms.FirstOrDefault(r => r.RoomNumber == updatedRoom.RoomNumber);
        if (existing != null)
        {
            existing.Description = updatedRoom.Description;
            existing.PricePerMonth = updatedRoom.PricePerMonth;
            existing.ImagePath = updatedRoom.ImagePath;
        }
    }


    public static void UpdateRoom(Room oldRoom, Room newRoom)
    {
        var index = AuthService.CurrentUser?.Rooms.IndexOf(oldRoom) ?? -1;
        if (index >= 0)
        {
            AuthService.CurrentUser.Rooms[index] = newRoom;
            DataService.SaveData();
        }
    }

    public static List<Room> GetAvailableRooms()
        => GetRooms().Where(r => !r.IsOccupied).ToList();

    public static int GetTotalRoomCount() => GetRooms().Count;
    public static int GetOccupiedRoomCount() => GetRooms().Count(r => r.IsOccupied);
    public static int GetAvailableRoomCount() => GetRooms().Count(r => !r.IsOccupied);

    public static void AssignTenantToRoom(Room room, Tenant tenant)
    {
        tenant.Room = room; // SET agar IsPaidThisMonth bisa akses price-nya
        room.Tenant = tenant;

        // Hapus auto pembayaran
        // tenant.Payments.Add(new Payment { Date = DateTime.Now, Amount = room.PricePerMonth });

        DataService.SaveData();
    }




    public static int GetPaidTenantCount()
        => GetRooms().Count(r => r.Tenant != null && r.Tenant.IsPaidThisMonth);



    public static int GetUnpaidTenantCount()
    => GetRooms().Count(r => r.Tenant != null && !r.Tenant.IsPaidThisMonth);

}