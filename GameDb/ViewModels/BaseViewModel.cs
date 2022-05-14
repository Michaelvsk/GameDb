﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Michaelvsk.GameDb.ViewModels;

internal class BaseViewModel : INotifyPropertyChanged
{

    string title = string.Empty;
    public string Title
    {
        get { return title; }
        set { SetProperty(ref title, value); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }
}
