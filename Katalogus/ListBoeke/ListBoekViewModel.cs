using Biblioteek.Types;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Biblioteek.Katalogus
{
    public class ListBoekViewModel : INotifyPropertyChanged
    {
        public ListBoekViewModel() => this.Boeke = new ObservableCollection<BoekViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BoekViewModel> Boeke { get; private set; }
        public IListBoekModel ListBoekModel { get; set; }
        public SignalEditBoek SignalEditBoek { get; set; }

        public void Initialize()
        {
            this.ListBoekModel.Initialize();
            this.ListBoekModel.BoekAdded += this.ListBoekModel_BoekAdded;
            this.ListBoekModel.BoekUpdated += this.ListBoekModel_BoekUpdated;

            this.LoadAll();
        }

        private void LoadAll()
        {

        }

        private void ListBoekModel_BoekAdded(object sender, BoekInformation e)
        {
            this.Boeke.Insert(0, new BoekViewModel(e, this.SignalEditBoek));
        }

        private void ListBoekModel_BoekUpdated(object sender, BoekInformation e)
        {
            this.Boeke.Remove(this.Boeke.First(b => b.BeokNommer.Equals(e.BoekNommer)));
            this.Boeke.Insert(0, new BoekViewModel(e, this.SignalEditBoek));
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}