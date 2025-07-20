using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class DetailTenantPage : ContentPage
{
    private readonly Room _room;
    private readonly Tenant _tenant;

    public DetailTenantPage(Room room, Tenant tenant)
    {
        InitializeComponent();
        _room = room;
        _tenant = tenant;
        RefreshUI();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private void RefreshUI()
    {
        nameLabel.Text = $"Nama: {_tenant.Name}";
        roomLabel.Text = $"Kamar: {_room.RoomNumber}";
        priceLabel.Text = $"Harga Sewa per Bulan: Rp {_room.PricePerMonth:N0}";
        paymentLabel.Text = $"Total Dibayar: Rp {_tenant.TotalPaid:N0}";
    }


    private async void OnEditClicked(object sender, EventArgs e)
    {
        string newName = await DisplayPromptAsync("Edit Nama", "Masukkan nama baru:", initialValue: _tenant.Name);
        if (!string.IsNullOrWhiteSpace(newName))
        {
            _tenant.Name = newName;
            RefreshUI();
        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Hapus", "Yakin ingin menghapus penyewa ini?", "Ya", "Tidak");
        if (confirm)
        {
            _room.Tenant = null;
            await Navigation.PopAsync();
        }
    }
}
