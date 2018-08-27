using System.ComponentModel;

namespace Biblioteek.Types
{
    public interface IVlaue<T> : INotifyPropertyChanged
    {
        T Value { get; set; }

        void Reset();
    }
}