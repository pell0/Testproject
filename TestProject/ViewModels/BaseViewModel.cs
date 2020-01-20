using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestProject.ViewModels
{
    public class BaseViewModel : INotifyCollectionChanged, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void OnNotifyCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            this.CollectionChanged?.Invoke(this, args);
        }
    }
}
