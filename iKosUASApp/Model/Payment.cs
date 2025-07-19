using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iKosUASApp.Model;

public class Payment
{
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public bool IsPaid => Amount > 0;
}