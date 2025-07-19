using iKosUASApp.Model;

namespace iKosUASApp.Pages;

public partial class TenantPaymentDetailPage : ContentPage
{
    private Tenant _tenant;

    public TenantPaymentDetailPage(Tenant tenant)
    {
        InitializeComponent();
        _tenant = tenant;
        tenantNameLabel.Text = tenant.Name;
        paymentListView.ItemsSource = _tenant.Payments;
    }

    private async void OnAddPaymentClicked(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("Tambah Pembayaran", "Masukkan jumlah (Rp):", keyboard: Keyboard.Numeric);
        if (double.TryParse(result, out double amount))
        {
            _tenant.Payments.Add(new Payment
            {
                Date = DateTime.Now,
                Amount = amount
            });

            paymentListView.ItemsSource = null;
            paymentListView.ItemsSource = _tenant.Payments;

            await DisplayAlert("Info", _tenant.IsPaidThisMonth
                ? "Pembayaran bulan ini sudah lunas."
                : "Pembayaran bulan ini masih kurang.", "OK");
        }

    }
}
