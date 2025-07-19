using System.ComponentModel;
using System.Runtime.CompilerServices;
using iKosUASApp.Model;
using System.Collections.Generic;


public class Room : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _roomNumber;
    public string RoomNumber
    {
        get => _roomNumber;
        set => SetProperty(ref _roomNumber, value);
    }

    private string _description;
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    private string? _imagePath;
    public string? ImagePath
    {
        get => _imagePath;
        set => SetProperty(ref _imagePath, value);
    }

    private double _pricePerMonth;
    public double PricePerMonth
    {
        get => _pricePerMonth;
        set => SetProperty(ref _pricePerMonth, value);
    }

    private Tenant? _tenant;
    public Tenant? Tenant
    {
        get => _tenant;
        set => SetProperty(ref _tenant, value);
    }

    public bool IsOccupied => Tenant != null;

    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

        storage = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }
}
