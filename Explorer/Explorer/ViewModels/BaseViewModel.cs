﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Explorer.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {
        //private bool isBusy = false;
        //public bool IsBusy {
        //    get { return this.isBusy; }
        //    set { this.SetProperty(ref this.isBusy, value); }
        //}

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null) {
            if(EqualityComparer<T>.Default.Equals(backingStore, value)) {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            this.OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChangedEventHandler changed = PropertyChanged;
            if(changed == null) {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
