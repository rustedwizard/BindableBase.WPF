using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindableBase
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetPropertyValue<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(field, value))
            {
                return false;
            }
            else
            {
                field = value;
                OnPropertyChanged(propertyName);
                return true;
            }
        }

        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
