using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Biblioteek.Katalogus
{
    public class KatalogusViewModel : INotifyPropertyChanged
    {
        private AddBoekView addBoek;
        private KatalogusModel model;

        public KatalogusViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddBoekView AddBoek
        {
            get => this.addBoek;

            set
            {
                this.addBoek = value;
                NotifyPropertyChanged();
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}