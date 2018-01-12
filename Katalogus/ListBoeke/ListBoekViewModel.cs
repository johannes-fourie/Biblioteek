using Biblioteek.Types;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Biblioteek.Katalogus
{
    public class ListBoekViewModel : INotifyPropertyChanged
    {
        public ListBoekViewModel() => this.Boeke = new ObservableCollection<BoekInformation>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BoekInformation> Boeke { get; private set; }

        public IListBoekModel ListBoekModel { get; set; }

        public void Initialize()
        {
            this.ListBoekModel.Initialize();
            this.ListBoekModel.BoekAdded += this.ListBoekModel_BoekAdded;
        }

        private void ListBoekModel_BoekAdded(object sender, BoekInformation e)
        {
            this.Boeke.Add(e);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}