using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class EditRoomPage : ContentPage
{
    private Room _room;

    public EditRoomPage(Room room)
    {
        InitializeComponent();
        _room = room;
        roomNumberEntry.Text = room.RoomNumber;
        descriptionEntry.Text = room.Description;
        priceEntry.Text = room.PricePerMonth.ToString();
        if (!string.IsNullOrEmpty(room.ImagePath) && File.Exists(room.ImagePath))
        {
            pickedImage.Source = ImageSource.FromFile(room.ImagePath);
        }
       

    }
    private string? imagePath;

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pilih Gambar",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                pickedImage.Source = ImageSource.FromStream(() => stream);
                imagePath = result.FullPath;

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Gagal memilih gambar: {ex.Message}", "OK");
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _room.RoomNumber = roomNumberEntry.Text;
        _room.Description = descriptionEntry.Text;
        _room.PricePerMonth = double.TryParse(priceEntry.Text, out var p) ? p : 0;

        if (!string.IsNullOrEmpty(imagePath))
        {
            _room.ImagePath = imagePath;
        }

        RoomService.UpdateRoom(_room);
        await Navigation.PopAsync();
    }

}