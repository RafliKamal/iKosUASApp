using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using iKosUASApp.Model;

public class Tenant : INotifyPropertyChanged
{
    public string Name { get; set; }

    private ObservableCollection<Payment> _payments = new();
    public ObservableCollection<Payment> Payments
    {
        get => _payments;
        set
        {
            if (_payments != value)
            {
                if (_payments != null)
                    _payments.CollectionChanged -= OnPaymentsChanged;

                _payments = value;
                _payments.CollectionChanged += OnPaymentsChanged;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalPaid));
                OnPropertyChanged(nameof(IsPaidThisMonth));
            }
        }
    }

    [JsonIgnore] 
    public Room? Room { get; set; }

    public double TotalPaid => Payments.Sum(p => p.Amount);

    public bool IsPaidThisMonth
    {
        get
        {
            if (Room == null) return false;
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var paidThisMonth = Payments
                .Where(p => p.Date.Month == currentMonth && p.Date.Year == currentYear)
                .Sum(p => p.Amount);

            return paidThisMonth >= Room.PricePerMonth;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private void OnPaymentsChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        OnPropertyChanged(nameof(TotalPaid));
        OnPropertyChanged(nameof(IsPaidThisMonth));
    }

    public Tenant()
    {
        Payments.CollectionChanged += OnPaymentsChanged;
    }
}
