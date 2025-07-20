using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class PaymentPage : ContentPage
{
    public PaymentPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTenantPayments();
    }

    private void LoadTenantPayments()
    {
        var rooms = RoomService.GetRooms();
        var allTenants = rooms
            .Where(r => r.Tenant != null)
            .Select(r => r.Tenant!)
            .ToList();

        var paid = allTenants.Where(t => t.IsPaidThisMonth).ToList();
        var unpaid = allTenants.Where(t => !t.IsPaidThisMonth).ToList();

        paidList.ItemsSource = paid;
        unpaidList.ItemsSource = unpaid;

        // Cek jumlah tenant
        bool hasTenant = allTenants.Count > 0;

        emptyPaidLabel.IsVisible = hasTenant && paid.Count == 0;
        emptyUnpaidLabel.IsVisible = hasTenant && unpaid.Count == 0;

        // Tambahan opsional: sembunyikan semua jika tidak ada tenant
        if (!hasTenant)
        {
            emptyPaidLabel.Text = "Belum ada data penyewa.";
            emptyUnpaidLabel.Text = "Belum ada data penyewa.";
            emptyPaidLabel.IsVisible = true;
            emptyUnpaidLabel.IsVisible = true;
        }
    }


    private async void OnTenantSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Tenant selectedTenant)
        {
            await Navigation.PushAsync(new TenantPaymentDetailPage(selectedTenant));
        }

        ((CollectionView)sender).SelectedItem = null;
    }
}
