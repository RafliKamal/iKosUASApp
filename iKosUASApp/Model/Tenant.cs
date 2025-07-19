using System.Collections.ObjectModel;
using System.Linq;

namespace iKosUASApp.Model;

public class Tenant
{
    public string Name { get; set; }

    public ObservableCollection<Payment> Payments { get; set; } = new();

    public double TotalPaid => Payments.Sum(p => p.Amount);
}
