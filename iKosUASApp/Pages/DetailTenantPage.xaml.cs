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

    private void RefreshUI()
    {
        nameLabel.Text = $"Nama: {_tenant.Name}";
        roomLabel.Text = $"Kamar: {_room.RoomNumber}";
        paymentLabel.Text = $"Total Dibayar: Rp {_tenant.TotalPaid:N0}";
    }

    private async void OnAddPaymentClicked(object sender, EventArgs e)
    {
        string input = await DisplayPromptAsync("Tambah Pembayaran", "Masukkan nominal pembayaran (Rp):", keyboard: Keyboard.Numeric);

        if (double.TryParse(input, out double amount) && amount > 0)
        {
            _tenant.Payments.Add(new Payment
            {
                Date = DateTime.Now,
                Amount = amount
            });

            RefreshUI();
        }
        else
        {
            await DisplayAlert("Error", "Nominal tidak valid.", "OK");
        }
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
