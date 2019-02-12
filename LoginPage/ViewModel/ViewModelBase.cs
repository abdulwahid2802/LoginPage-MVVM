using System;
using System.ComponentModel;

namespace LoginPage.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;

            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
