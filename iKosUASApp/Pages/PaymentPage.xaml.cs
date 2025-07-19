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
        var allTenants = RoomService.GetRooms()
            .Where(r => r.Tenant != null)
            .Select(r => r.Tenant)
            .ToList();

        var paid = allTenants.Where(t => t.IsPaidThisMonth).ToList();
        var unpaid = allTenants.Where(t => !t.IsPaidThisMonth).ToList();

        paidList.ItemsSource = paid;
        unpaidList.ItemsSource = unpaid;
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
