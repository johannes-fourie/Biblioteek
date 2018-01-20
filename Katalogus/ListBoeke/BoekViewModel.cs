using Biblioteek.Types;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Biblioteek.Katalogus
{
    public class BoekViewModel : INotifyPropertyChanged
    {
        private BoekInformation boek;

        private SignalEditBoek signalEditBoek;

        public BoekViewModel(BoekInformation boek, SignalEditBoek signalEditBoek)
        {
            this.boek = boek;
            this.signalEditBoek = signalEditBoek;

            this.EditBoekCommand = new EditBoekICommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BoekNommer BeokNommer
        {
            get => this.boek.BoekNommer;
        }

        public string BoekDisplay
        {
            get => this.boek.ToString();
        }

        public EditBoekICommand EditBoekCommand { get; set; }

        internal void EditBoek()
        {
            this.signalEditBoek.EditThisBoekNow(this.boek.BoekNommer);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class EditBoekICommand : ICommand
        {
            private BoekViewModel boekView;

            public EditBoekICommand(BoekViewModel boekView)
            {
                this.boekView = boekView;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter) => true;

            public void Execute(object parameter)
            {
                boekView.EditBoek();
            }
        }
    }
}