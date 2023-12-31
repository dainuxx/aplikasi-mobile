﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppBM.ModelViews
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        // set title empty
        string title = string.Empty;
        public string Title
        {
            get { return Title; }
            set { SetProperty(ref title, value); }
        }

        // Arguments Set Property
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName="", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            // else
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //OnPropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string propertyName ="")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
