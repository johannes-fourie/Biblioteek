using Biblioteek.Types;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Biblioteek.Katalogus
{
    public class AddBoekViewModel : INotifyPropertyChanged
    {
        private Genres genre = Genres.Fiksie;
        private int jaar;
        private int nommer;
        private OuderdomsGroepe ouderdomsGroep = OuderdomsGroepe.Kleuter;
        private string skrywer;
        private string tietel;

        public AddBoekViewModel()
        {
            this.AddBoekCommand = new AddBoekICommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddBoekICommand AddBoekCommand { get; set; }

        public IAddBoekModel AddBoekModel { get; set; }

        private BoekNommer lastAddedBoekNommer;
        
        public BoekNommer LastAddedBoekNommer
        {
            get => this.lastAddedBoekNommer;

            set
            {
                this.lastAddedBoekNommer = value;
                NotifyPropertyChanged();
            }
        }

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

        public int Jaar
        {
            get => this.jaar;

            set
            {
                this.jaar = value;
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

        private string lastBoek;

        public string LastBoekAdded
        {
            get => this.lastBoek;
            private set
            {
                this.lastBoek = value;
                NotifyPropertyChanged();
            }
        }

        public void Initialize()
        {
            this.AddBoekModel.Initialize();
            var next_boek_nommer = AddBoekModel.NextBoekNommer();
            this.Jaar = next_boek_nommer.Jaar;
            this.Nommer = next_boek_nommer.Nommer;
        }

        private void ClearInputs()
        {
            this.Tietel = string.Empty;
            this.Skrywer = string.Empty;

            var next_boek_nommer = AddBoekModel.NextBoekNommer();
            this.Jaar = next_boek_nommer.Jaar;
            this.Nommer = next_boek_nommer.Nommer;
        }

        protected void AddBoek()
        {
            var info = new BoekInformation(
                tietel: this.Tietel.ToTietel(),
                skrywer: this.Skrywer.ToSkrywer(),
                genre: this.Genre,
                ouderdomsGroep: this.OuderdomsGroep,
                boekNommer: new BoekNommer(this.Jaar, this.Nommer));

            var result = this.AddBoekModel.AddBoek(info);

            if (result == AddResult.AddSuccess)
            {
                this.LastBoekAdded = $@"{info.Tietel}; {info.Skrywer}; {info.BoekNommer}";
                this.LastAddedBoekNommer = info.BoekNommer;
                this.ClearInputs();
            }
            else
                this.LastBoekAdded = "Boek is nie bygevoeg nie.";
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