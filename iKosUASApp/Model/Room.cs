using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iKosUASApp.Model;

public class Room
{
    public string RoomNumber { get; set; }
    public string Description { get; set; }
    public double PricePerMonth { get; set; }
    public string? ImagePath { get; set; }
    public bool IsOccupied => Tenant != null;
    public Tenant? Tenant { get; set; }
}