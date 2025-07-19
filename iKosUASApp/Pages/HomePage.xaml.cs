using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadDashboard();
    }

    private void LoadDashboard()
    {
        totalLabel.Text = RoomService.GetTotalRoomCount().ToString();
        occupiedLabel.Text = RoomService.GetOccupiedRoomCount().ToString();
        availableLabel.Text = RoomService.GetAvailableRoomCount().ToString();
        paidLabel.Text = RoomService.GetPaidTenantCount().ToString();
        unpaidLabel.Text = RoomService.GetUnpaidTenantCount().ToString();

    }
}
