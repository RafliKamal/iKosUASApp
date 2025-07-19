using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class PaymentPage : ContentPage
{
    public PaymentPage()
    {
        InitializeComponent();
        LoadTenantPayments();
    }

    private void LoadTenantPayments()
    {
        var tenants = RoomService.GetRooms()
            .Where(r => r.Tenant != null)
            .Select(r => r.Tenant)
            .ToList();

        paymentList.ItemsSource = tenants;
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
