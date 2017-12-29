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
        private OuderdomsGroepe ouderdomsGroep = OuderdomsGroepe.Tiener;
        private string skrywer;
        private string tietel;

        public AddBoekViewModel()
        {
            this.Add_boek_command = new Add_boek_ICommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IAdd_boek_model Add_boek_model { get; set; }

        public Add_boek_ICommand Add_boek_command { get; set; }

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

        public void Initialize()
        {
            var next_boek_nommer = Add_boek_model.Next_boek_nommer();
            this.Jaar = next_boek_nommer.Jaar;
            this.Nommer = next_boek_nommer.Nommer;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class Add_boek_ICommand : ICommand
        {
            private AddBoekViewModel boek_view;

            public Add_boek_ICommand(AddBoekViewModel boek_view)
            {
                this.boek_view = boek_view;
                this.boek_view.PropertyChanged += BoekViewPropertyChanged;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return !string.IsNullOrWhiteSpace(boek_view.Tietel)
                    && !string.IsNullOrWhiteSpace(boek_view.Skrywer)
                    && boek_view.Nommer > 0
                    && boek_view.Jaar > 0;
            }

            public void Execute(object parameter)
            {
                //throw new NotImplementedException();
            }

            private void BoekViewPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}