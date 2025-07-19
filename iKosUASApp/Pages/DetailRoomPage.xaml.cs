using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class DetailRoomPage : ContentPage
{
    private Room room;

    public DetailRoomPage(Room room)
    {
        InitializeComponent();
        this.room = room;

        roomNumberLabel.Text = $"Nomor: {room.RoomNumber}";
        descriptionLabel.Text = $"Deskripsi: {room.Description}";
        tenantLabel.Text = room.Tenant != null ? $"Penyewa: {room.Tenant.Name}" : "Belum ditempati";
    priceLabel.Text = $"Harga Per Bulan: Rp{room.PricePerMonth}";
        roomImage.Source = room.ImagePath;
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        RoomService.RemoveRoom(room);
        await Navigation.PopAsync();
    }
}