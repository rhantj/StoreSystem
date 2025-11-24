using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DataViewModel : INotifyPropertyChanged
{
    private ItemData _dataModel;

    public DataViewModel(ItemData data)
    {
        _dataModel = data;
        Name = data.d_Name;
        Count = data.d_Count;
    }

    public string Name
    {
        get => _dataModel.d_Name;
        set
        {
            _dataModel.d_Name = value;
            OnPropertyChanged();
        }
    }

    public string Description
    {
        get => _dataModel.d_Description;
        set
        {
            _dataModel.d_Description = value;
            OnPropertyChanged();
        }
    }

    public int Count
    {
        get => _dataModel.d_Count;
        set
        {
            _dataModel.d_Count = value;
            OnPropertyChanged();
        }
    }

    public int Price
    {
        get => _dataModel.d_Price;
        set
        {
            _dataModel.d_Price = value;
            OnPropertyChanged();
        }
    }

    public Sprite Icon
    {
        get => _dataModel.d_Icon;
        set
        {
            _dataModel.d_Icon = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}