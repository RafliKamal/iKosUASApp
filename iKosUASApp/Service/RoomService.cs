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
    }

    public static void RemoveRoom(Room room)
    {
        AuthService.CurrentUser?.Rooms.Remove(room);
    }

    public static List<Room> GetAvailableRooms()
        => GetRooms().Where(r => !r.IsOccupied).ToList();

    public static int GetTotalRoomCount() => GetRooms().Count;
    public static int GetOccupiedRoomCount() => GetRooms().Count(r => r.IsOccupied);
    public static int GetAvailableRoomCount() => GetRooms().Count(r => !r.IsOccupied);

    public static void AssignTenantToRoom(Room room, Tenant tenant)
    {
        room.Tenant = tenant;

        // Catat pembayaran pertama saat tenant mulai menempati kamar
        tenant.Payments.Add(new Payment
        {
            Date = DateTime.Now,
            Amount = room.PricePerMonth
        });
    }

    public static int GetPaidTenantCount() => GetRooms().Count(r => r.Tenant?.Payments.Any(p => p.IsPaid) == true);
    public static int GetUnpaidTenantCount() => GetRooms().Count(r => r.Tenant != null && r.Tenant.Payments.All(p => !p.IsPaid));
}
