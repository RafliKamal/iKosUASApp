using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iKosUASApp.Model;

public class Tenant
{
    public string Name { get; set; }
    public List<Payment> Payments { get; set; } = new();
}