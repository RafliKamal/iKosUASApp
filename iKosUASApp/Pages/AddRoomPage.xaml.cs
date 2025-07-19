using iKosUASApp.Model;
using iKosUASApp.Service;

namespace iKosUASApp.Pages;

public partial class AddRoomPage : ContentPage
{
    private string? imagePath;
    private FileResult? pickedFile;

    public AddRoomPage()
    {
        InitializeComponent();
    }

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        try
        {
            pickedFile = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pilih Gambar",
                FileTypes = FilePickerFileType.Images
            });

            if (pickedFile != null)
            {
                imagePath = pickedFile.FullPath;

                var stream = await pickedFile.OpenReadAsync();
                pickedImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Gagal memuat gambar: {ex.Message}", "OK");
        }
    }


    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (AuthService.CurrentUser == null)
        {
            await DisplayAlert("Error", "Silakan login terlebih dahulu.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(roomNumberEntry.Text))
        {
            await DisplayAlert("Validasi", "Nomor kamar harus diisi.", "OK");
            return;
        }

        var room = new Room
        {
            RoomNumber = roomNumberEntry.Text.Trim(),
            Description = descriptionEntry.Text?.Trim(),
            PricePerMonth = double.TryParse(priceEntry.Text, out var price) ? price : 0,
            ImagePath = imagePath
        };

        RoomService.AddRoom(room);
        await Navigation.PopAsync();
    }

   
}
