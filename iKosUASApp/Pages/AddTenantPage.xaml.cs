using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class AddTenantPage : ContentPage
{
    private List<Room> availableRooms;

    public AddTenantPage()
    {
        InitializeComponent();
        availableRooms = RoomService.GetAvailableRooms();
        roomPicker.ItemsSource = availableRooms.Select(r => r.RoomNumber).ToList();
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text;
        string selectedRoomNumber = roomPicker.SelectedItem?.ToString();
        var room = availableRooms.FirstOrDefault(r => r.RoomNumber == selectedRoomNumber);

        if (!string.IsNullOrWhiteSpace(name) && room != null)
        {
            RoomService.AssignTenantToRoom(room, new Tenant { Name = name });
            Navigation.PopAsync();
        }
    }
}