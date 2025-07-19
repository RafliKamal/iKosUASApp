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
        availableRoomsView.ItemsSource = RoomService.GetAvailableRooms();
        occupiedRoomsView.ItemsSource = RoomService.GetRooms().Where(r => r.IsOccupied).ToList();
    }



    private async void OnAddRoomClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddRoomPage());
    }


    private async void OnRoomTapped(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Room selectedRoom)
        {
            await Navigation.PushAsync(new DetailRoomPage(selectedRoom));
        }
    }
}