using Biblioteek.Types;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Biblioteek.Katalogus
{
    public class AddBoekViewModel : INotifyPropertyChanged
    {
        private string boekSummary;
        private string dewey;
        private int jaar;
        private BoekNommer lastAddedBoekNommer;
        private string lastBoek;
        private int nommer;
        private OuderdomsGroepe ouderdomsGroep = OuderdomsGroepe.Kleuter;
        private string skrywer;
        private string tietel;

        public AddBoekViewModel()
        {
            this.AddBoekCommand = new AddBoekICommand(this);
            this.Taal = new Taal(default);
            this.Genre = new Genre(default);
            this.OuderdomsGroep = new OuderdomsGroep(default);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddBoekICommand AddBoekCommand { get; set; }

        public IAddBoekModel AddBoekModel { get; set; }

        public string BoekSummary
        {
            get => this.boekSummary;

            private set
            {
                this.boekSummary = value;
                NotifyPropertyChanged();
            }
        }

        public string Dewey
        {
            get => this.dewey;
            set
            {
                this.dewey = value;
                this.NotifyPropertyChanged();
            }
        }

        public Genre Genre { get; private set; }

        public int Jaar
        {
            get => this.jaar;

            set
            {
                this.jaar = value;
                NotifyPropertyChanged();
            }
        }

        public BoekNommer LastAddedBoekNommer
        {
            get => this.lastAddedBoekNommer;

            set
            {
                this.lastAddedBoekNommer = value;
                NotifyPropertyChanged();
            }
        }

        public string LastBoekAdded
        {
            get => this.lastBoek;
            private set
            {
                this.lastBoek = value;
                NotifyPropertyChanged();
            }
        }

        public int Nommer
        {
            get => this.nommer;

            set
            {
                this.nommer = value;
                NotifyPropertyChanged();
            }
        }

        public OuderdomsGroep OuderdomsGroep { get; private set; }

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

        public Taal Taal { get; private set; }

        public void Initialize()
        {
            this.AddBoekModel.Initialize();
            var next_boek_nommer = AddBoekModel.NextBoekNommer();
            this.Jaar = next_boek_nommer.Jaar;
            this.Nommer = next_boek_nommer.Nommer;
        }

        protected void AddBoek()
        {
            var info = new BoekInformation(
                tietel: this.Tietel.ToTietel(),
                skrywer: this.Skrywer.ToSkrywer(),
                genre: this.Genre.Value,
                ouderdomsGroep: this.OuderdomsGroep.Value,
                boekNommer: new BoekNommer(this.Jaar, this.Nommer),
                dewey: this.Dewey.ToDewey(),
                taal: this.Taal.Value);

            var result = this.AddBoekModel.AddBoek(info);

            if (result == ActionResult.Success)
            {
                this.LastBoekAdded = info.ToString();
                this.LastAddedBoekNommer = info.BoekNommer;
                this.BoekSummary = info.ToString();
                this.ClearInputs();
            }
            else
                this.LastBoekAdded = "Boek is nie bygevoeg nie.";
        }

        private void ClearInputs()
        {
            this.Tietel = string.Empty;
            this.Skrywer = string.Empty;
            this.Dewey = string.Empty;

            var next_boek_nommer = AddBoekModel.NextBoekNommer();
            this.Jaar = next_boek_nommer.Jaar;
            this.Nommer = next_boek_nommer.Nommer;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class AddBoekICommand : ICommand
        {
            private AddBoekViewModel boekView;

            public AddBoekICommand(AddBoekViewModel boekView)
            {
                this.boekView = boekView;
                this.boekView.PropertyChanged += BoekViewPropertyChanged;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return !string.IsNullOrWhiteSpace(boekView.Tietel)
                    && !string.IsNullOrWhiteSpace(boekView.Skrywer)
                    && !string.IsNullOrWhiteSpace(boekView.Dewey)
                    && boekView.Nommer > 0
                    && boekView.Jaar > 0;
            }

            public void Execute(object parameter)
            {
                boekView.AddBoek();
            }

            private void BoekViewPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}