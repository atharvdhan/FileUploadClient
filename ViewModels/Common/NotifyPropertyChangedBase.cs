using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace FileUploadClient.ViewModels.Common
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Set<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (!Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(name);
            }
        }
        protected void RaisePropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
