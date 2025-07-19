using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iKosUASApp.Model;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public ObservableCollection<Room> Rooms { get; set; } = new();
    public List<Tenant> Tenants { get; set; } = new();
}