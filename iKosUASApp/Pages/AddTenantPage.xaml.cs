using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class AddTenantPage : ContentPage
{
    private List<Room> availableRooms = new();

    public AddTenantPage()
    {
        InitializeComponent();

        availableRooms = RoomService.GetAvailableRooms();

        if (availableRooms.Count == 0)
        {
            noRoomLabel.IsVisible = true;
            roomPicker.IsEnabled = false;
        }
        else
        {
            noRoomLabel.IsVisible = false;
            roomPicker.ItemsSource = availableRooms.Select(r => r.RoomNumber).ToList();
            roomPicker.IsEnabled = true;
        }
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text?.Trim() ?? "";
        string selectedRoomNumber = roomPicker.SelectedItem?.ToString();
        var room = availableRooms.FirstOrDefault(r => r.RoomNumber == selectedRoomNumber);

        if (string.IsNullOrWhiteSpace(name))
        {
            await DisplayAlert("Validasi", "Nama penyewa harus diisi.", "OK");
            return;
        }

        if (room == null)
        {
            await DisplayAlert("Validasi", "Silakan pilih kamar yang tersedia.", "OK");
            return;
        }

        RoomService.AssignTenantToRoom(room, new Tenant { Name = name });
        await DisplayAlert("Sukses", "Penyewa berhasil ditambahkan.", "OK");
        await Navigation.PopAsync();
    }
}
