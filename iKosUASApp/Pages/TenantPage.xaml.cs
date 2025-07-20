using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class TenantPage : ContentPage
{
    public TenantPage()
    {
        InitializeComponent();
        RefreshTenants();
    }

    private void RefreshTenants()
    {
        var viewModels = RoomService.GetRooms()
            .Where(r => r.Tenant != null)
            .Select(r => new TenantViewModel
            {
                Room = r,
                Tenant = r.Tenant!
            })
            .ToList();

        tenantView.ItemsSource = viewModels;
        emptyLabel.IsVisible = viewModels.Count == 0;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshTenants();
    }

    private async void OnTenantTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is TenantViewModel selected)
        {
            await Navigation.PushAsync(new DetailTenantPage(selected.Room, selected.Tenant));
        }
    }

    private async void OnAddTenantClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTenantPage());
    }
}
