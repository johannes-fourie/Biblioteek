using System.ComponentModel;
using System.Runtime.CompilerServices;
using Biblioteek.Services;
using Biblioteek.Types;

namespace Biblioteek.Katalogus
{
    public class KatalogusViewModel : INotifyPropertyChanged
    {
        private BoekNommer lastAddedBoekNommer;

        public KatalogusViewModel()
        {
        }

        public BoekNommer LastAddedBoekNommerO
        {
            get => this.lastAddedBoekNommer;
            set
            {
                this.lastAddedBoekNommer = value;
                this.NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}