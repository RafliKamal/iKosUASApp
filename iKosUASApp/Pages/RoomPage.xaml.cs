using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class RoomPage : ContentPage
{
    public RoomPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshRooms();
    }


    private void RefreshRooms()
    {
        var availableRooms = RoomService.GetAvailableRooms();
        var occupiedRooms = RoomService.GetRooms().Where(r => r.IsOccupied).ToList();

        availableRoomsView.ItemsSource = availableRooms;
        occupiedRoomsView.ItemsSource = occupiedRooms;

        noAvailableRoomsLabel.IsVisible = availableRooms.Count == 0;
        noOccupiedRoomsLabel.IsVisible = occupiedRooms.Count == 0;
    }



    private async void OnAddRoomClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRoomPage());
    }


    private async void OnRoomTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Room selectedRoom)
        {
            await Navigation.PushAsync(new DetailRoomPage(selectedRoom));
        }
    }

}