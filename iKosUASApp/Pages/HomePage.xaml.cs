using iKosUASApp.Service;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace iKosUASApp.Pages;

public partial class HomePage : ContentPage
{
 

    public HomePage()   
    {
        InitializeComponent();

        LoadUserProfile();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadDashboardData();
        LoadUserProfile();
    }

    private void LoadUserProfile()
    {
        var user = AuthService.CurrentUser;

        if (user != null && !string.IsNullOrEmpty(user.ProfileImagePath))
        {
            profileImageButton.Source = ImageSource.FromFile(user.ProfileImagePath);
        }
        else
        {
            profileImageButton.Source = "profile.png"; 
        }

        kosNameLabel.Text = user?.KosName ?? "Kos Saya";
    }

    private async void OnProfileImageClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }

    private void LoadDashboardData()
    {
        var total = RoomService.GetTotalRoomCount();
        var occupied = RoomService.GetOccupiedRoomCount();
        var available = RoomService.GetAvailableRoomCount();
        var paid = RoomService.GetPaidTenantCount();
        var unpaid = RoomService.GetUnpaidTenantCount();
        var tenant = RoomService.GetRooms().Count(r => r.Tenant != null);
        var income = RoomService.GetRooms()
            .Where(r => r.Tenant != null)
            .SelectMany(r => r.Tenant.Payments)
            .Where(p => p.Date.Month == DateTime.Now.Month && p.Date.Year == DateTime.Now.Year)
            .Sum(p => p.Amount);

        totalLabel.Text = total.ToString();
        occupiedLabel.Text = occupied.ToString();
        availableLabel.Text = available.ToString();
        paidLabel.Text = paid.ToString();
        unpaidLabel.Text = unpaid.ToString();
        tenantLabel.Text = tenant.ToString();
        incomeLabel.Text = $"Rp{income:N0}";
        kosNameLabel.Text = AuthService.CurrentUser?.KosName ?? "Nama Kos";
    }
}
