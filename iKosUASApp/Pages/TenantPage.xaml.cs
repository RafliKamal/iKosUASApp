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
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshTenants();
    }

    private async void OnTenantSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is TenantViewModel selected)
        {
            await Navigation.PushAsync(new DetailTenantPage(selected.Room, selected.Tenant));
        }

        ((CollectionView)sender).SelectedItem = null;
    }

    private async void OnAddTenantClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTenantPage());
    }
}