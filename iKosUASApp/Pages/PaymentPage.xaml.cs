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
            .Select(r => r.Tenant!)
            .ToList();

        var paid = allTenants.Where(t => t.IsPaidThisMonth).ToList();
        var unpaid = allTenants.Where(t => !t.IsPaidThisMonth).ToList();

        paidList.ItemsSource = paid;
        unpaidList.ItemsSource = unpaid;

        emptyPaidLabel.IsVisible = paid.Count == 0;
        emptyUnpaidLabel.IsVisible = unpaid.Count == 0 || allTenants.Count == 0;
    }

    private async void OnTenantTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Tenant selectedTenant)
        {
            await Navigation.PushAsync(new TenantPaymentDetailPage(selectedTenant));
        }
    }
}
