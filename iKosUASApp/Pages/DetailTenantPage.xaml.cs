using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class DetailTenantPage : ContentPage
{
    private Room room;

    public DetailTenantPage(Room room, Tenant tenant)
    {
        InitializeComponent();
        this.room = room;

        roomLabel.Text = $"Kamar: {room.RoomNumber}";
        nameLabel.Text = $"Penyewa: {tenant.Name}";
    }

    private void OnDeleteTenantClicked(object sender, EventArgs e)
    {
        room.Tenant = null;
        Navigation.PopAsync();
    }
}
