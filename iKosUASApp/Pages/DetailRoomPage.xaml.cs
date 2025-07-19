using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class DetailRoomPage : ContentPage
{
    private Room _room;

    public DetailRoomPage(Room room)
    {
        InitializeComponent();
        _room = room;
        RefreshRoomInfo();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshRoomInfo();
    }

    private void RefreshRoomInfo()
    {
        roomNumberLabel.Text = _room.RoomNumber;
        descriptionLabel.Text = _room.Description;
        priceLabel.Text = $"Harga: Rp {_room.PricePerMonth:N0}";
        tenantLabel.Text = _room.Tenant != null
            ? $"Penyewa: {_room.Tenant.Name}"
            : "Belum ada penyewa";
        imageView.Source = _room.ImagePath;
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditRoomPage(_room));
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Hapus", "Yakin ingin menghapus kamar ini?", "Ya", "Tidak");
        if (confirm)
        {
            RoomService.RemoveRoom(_room);
            await Navigation.PopAsync();
        }
    }
}
