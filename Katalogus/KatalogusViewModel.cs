using Biblioteek.Types;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Biblioteek.Katalogus
{
    public class KatalogusViewModel : INotifyPropertyChanged
    {
        private bool addBoek;
        private bool editBoek = false;
        private BoekNommer lastAddedBoekNommer;

        public KatalogusViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool AddBoek
        {
            get => this.addBoek;

            set
            {
                this.addBoek = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool EditBoek
        {
            get => this.editBoek;

            set
            {
                this.editBoek = value;
                this.NotifyPropertyChanged();
            }
        }

        public SignalEditBoek SignalEditBoek { get; set; }

        public void Initialize()
        {
            SignalEditBoek.Edit += this.SignalEditBoek_Edit;
            SignalEditBoek.Finished += this.SignalEditBoek_Finished;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SignalEditBoek_Edit(object sender, BoekNommer e)
        {
            this.EditBoek = true;
        }

        private void SignalEditBoek_Finished(object sender, BoekNommer e)
        {
            this.AddBoek = true;
        }
    }
}