using Biblioteek.Types;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Biblioteek.Katalogus
{
    public class EditBoekViewModel : INotifyPropertyChanged
    {
        private BoekInformation boek;
        private string boekSummary;
        private string nommer;
        private string skrywer;
        private string tietel;
        private string dewey;

        public EditBoekViewModel()
        {
            this.UpdateBoekCommand = new UpdateBoekICommand(this);
            this.Taal = new Taal(default);
            this.Genre = new Genre(default);
            this.OuderdomsGroep = new OuderdomsGroep(default); 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string BoekSummary
        {
            get => this.boekSummary;

            private set
            {
                this.boekSummary = value;
                NotifyPropertyChanged();
            }
        }

        public IEditBoekModel EditBoekModel { get; set; }

        public Genre Genre { get; private set; }

        public string Nommer
        {
            get => this.nommer;

            set
            {
                this.nommer = value;
                NotifyPropertyChanged();
            }
        }

        public OuderdomsGroep OuderdomsGroep { get; private set; }

        public SignalEditBoek SignalEditBoek { get; set; }

        public string Skrywer
        {
            get => this.skrywer;
            set
            {
                this.skrywer = value;
                NotifyPropertyChanged();
            }
        }

        public string Tietel
        {
            get => this.tietel;
            set
            {
                this.tietel = value;
                NotifyPropertyChanged();
            }
        }

        public string Dewey
        {
            get => this.dewey;
            set
            {
                this.dewey = value;
                NotifyPropertyChanged();
            }
        }

        public Taal Taal { get; private set; }

        public UpdateBoekICommand UpdateBoekCommand { get; set; }

        public void Initialize()
        {
            this.EditBoekModel.Initialize();
            this.SignalEditBoek.Edit += this.SignalEditBoek_Edit;
        }

        internal void UpdateBoek()
        {
            this.EditBoekModel.UpdateBoek(new BoekInformation(
                this.Tietel.ToTietel(),
                this.Skrywer.ToSkrywer(),
                this.Genre.Value,
                this.OuderdomsGroep.Value,
                this.boek.BoekNommer,
                this.Dewey.ToDewey(),
                this.Taal.Value));

            SignalEditBoek.FinishedEditing(this.boek.BoekNommer);
        }

        private void Load(BoekNommer nommer)
        {
            var boek = this.EditBoekModel.GetBoek(nommer);
            if (boek.IsSome)
            {
                this.boek = boek.Value;
                this.Tietel = this.boek.Tietel.Value;
                this.Skrywer = this.boek.Skrywer.Value;
                this.Genre.Value = this.boek.Genre;
                this.OuderdomsGroep.Value = this.boek.OuderdomsGroep;
                this.Nommer = this.boek.BoekNommer.ToString();
                this.Dewey = this.boek.Dewey.Number;
                this.Taal.Value = this.boek.Taal;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SignalEditBoek_Edit(object sender, BoekNommer e)
        {
            Load(e);
        }

        public class UpdateBoekICommand : ICommand
        {
            private EditBoekViewModel editboekView;

            public UpdateBoekICommand(EditBoekViewModel editboekView)
            {
                this.editboekView = editboekView;
                this.editboekView.PropertyChanged += BoekViewPropertyChanged;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return !string.IsNullOrWhiteSpace(editboekView.Tietel)
                    && !string.IsNullOrWhiteSpace(editboekView.Skrywer);
            }

            public void Execute(object parameter)
            {
                editboekView.UpdateBoek();
            }

            private void BoekViewPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}