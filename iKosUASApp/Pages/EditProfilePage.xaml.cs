using iKosUASApp.Service;
using iKosUASApp.Model;

namespace iKosUASApp.Pages;

public partial class EditProfilePage : ContentPage
{
    private string? imagePath;

    public EditProfilePage()
    {
        InitializeComponent();

        var user = AuthService.CurrentUser;
        if (user != null)
        {
            kosNameEntry.Text = user.KosName;
            if (!string.IsNullOrEmpty(user.ProfileImagePath))
                profileImage.Source = ImageSource.FromFile(user.ProfileImagePath);
        }
    }

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pilih Gambar",
            FileTypes = FilePickerFileType.Images
        });

        if (result != null)
        {
            imagePath = result.FullPath;
            profileImage.Source = ImageSource.FromFile(imagePath);
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        var user = AuthService.CurrentUser;
        if (user != null)
        {
            user.KosName = kosNameEntry.Text ?? "";
            if (!string.IsNullOrEmpty(imagePath))
                user.ProfileImagePath = imagePath;

            AuthService.Save(); // simpan ke file
            DisplayAlert("Sukses", "Profil berhasil diperbarui", "OK");
        }
    }
}
