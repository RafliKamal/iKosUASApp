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
            else
                profileImage.Source = "profile.png";
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

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var user = AuthService.CurrentUser;
        if (user == null) return;

        string kosName = kosNameEntry.Text?.Trim() ?? "";

        if (string.IsNullOrWhiteSpace(kosName))
        {
            await DisplayAlert("Validasi", "Nama kosan tidak boleh kosong.", "OK");
            return;
        }

        user.KosName = kosName;

        if (!string.IsNullOrEmpty(imagePath))
            user.ProfileImagePath = imagePath;

        AuthService.Save();

        await DisplayAlert("Sukses", "Profil berhasil diperbarui.", "OK");


        Application.Current.MainPage = new NavigationPage(new MainNavigationPage());

    }
}
