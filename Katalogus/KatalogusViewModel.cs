using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Biblioteek
{
    public class KatalogusViewModel : INotifyPropertyChanged
    {
        private KatalogusModel _model;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private AddBoekView _addBoek;

        public AddBoekView AddBoek
        {
            get => _addBoek;

            set
            {
                _addBoek = value;
                NotifyPropertyChanged();
            }
        }
    }
}
