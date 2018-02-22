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
        private Genres genre;
        private string nommer;
        private OuderdomsGroepe ouderdomsGroep;
        private string skrywer;
        private string tietel;
        private string dewey;

        public EditBoekViewModel()
        {
            this.UpdateBoekCommand = new UpdateBoekICommand(this);
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

        public Genres Genre
        {
            get => this.genre;
            set
            {
                this.genre = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged("Is_Fiksie");
                this.NotifyPropertyChanged("Fiksie");
            }
        }

        public bool Is_fiksie
        {
            get => this.genre == Genres.Fiksie;
            set
            {
                if (value)
                    this.Genre = Genres.Fiksie;
            }
        }

        public bool Is_kleuter
        {
            get => this.ouderdomsGroep == OuderdomsGroepe.Kleuter;
            set
            {
                if (value)
                    this.ouderdomsGroep = OuderdomsGroepe.Kleuter;
            }
        }

        public bool Is_nie_fiksie
        {
            get => this.genre == Genres.Nie_fiksie;
            set
            {
                if (value)
                    this.Genre = Genres.Nie_fiksie;
            }
        }

        public bool Is_tiener
        {
            get => this.ouderdomsGroep == OuderdomsGroepe.Tiener;
            set
            {
                if (value)
                    this.ouderdomsGroep = OuderdomsGroepe.Tiener;
            }
        }

        public string Nommer
        {
            get => this.nommer;

            set
            {
                this.nommer = value;
                NotifyPropertyChanged();
            }
        }

        public OuderdomsGroepe OuderdomsGroep
        {
            get => this.ouderdomsGroep;
            set
            {
                this.ouderdomsGroep = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged("Is_tiener");
                this.NotifyPropertyChanged("Is_kleuter");
            }
        }

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
                this.Genre,
                this.OuderdomsGroep,
                this.boek.BoekNommer,
                this.Dewey.ToDewey()));

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
                this.Genre = this.boek.Genre;
                this.OuderdomsGroep = this.boek.OuderdomsGroep;
                this.Nommer = this.boek.BoekNommer.ToString();
                this.Dewey = this.boek.Dewey.Number;
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