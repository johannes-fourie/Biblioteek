using Biblioteek.Types;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Biblioteek.Katalogus
{
    public class AddBoekViewModel : NotifyPropertyChangedBase
    {
        private string boekSummary;
        private int jaar;
        private BoekNommer lastAddedBoekNommer;
        private string lastBoek;
        private int nommer;

        public AddBoekViewModel()
        {
            this.AddBoekCommand = new AddBoekICommand(this);

            this.Dewey = new Dewey();
            this.Dewey.PropertyChanged += this.ValuePropertyChanged;

            this.Genre = new Genre();
            this.Genre.PropertyChanged += this.ValuePropertyChanged;

            this.OuderdomsGroep = new OuderdomsGroep();
            this.OuderdomsGroep.PropertyChanged += this.ValuePropertyChanged;

            this.Skrywer = new Skrywer();
            this.Skrywer.PropertyChanged += this.ValuePropertyChanged;

            this.Taal = new Taal();
            this.Taal.PropertyChanged += this.ValuePropertyChanged;

            this.Tietel = new Tietel();
            this.Tietel.PropertyChanged += this.ValuePropertyChanged;
        }

        public void Refresh()
        {
            this.Genre.Value = this.Genre.Value;
            this.OuderdomsGroep.Value = this.OuderdomsGroep.Value;
            this.Taal.Value = this.Taal.Value;
        }

        public event EventHandler ValueChanged;

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

        public Dewey Dewey { get; private set; }

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

        public Skrywer Skrywer { get; private set; }

        public Taal Taal { get; private set; }

        public Tietel Tietel { get; private set; }

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
                tietel: this.Tietel,
                skrywer: this.Skrywer,
                genre: this.Genre.Value,
                ouderdomsGroep: this.OuderdomsGroep.Value,
                boekNommer: new BoekNommer(this.Jaar, this.Nommer),
                dewey: this.Dewey,
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
            this.Tietel.Reset();
            this.Skrywer.Reset();
            this.Dewey.Reset();

            var next_boek_nommer = AddBoekModel.NextBoekNommer();
            this.Jaar = next_boek_nommer.Jaar;
            this.Nommer = next_boek_nommer.Nommer;
        }

        private void ValuePropertyChanged(object sender, PropertyChangedEventArgs e) 
            => this.ValueChanged?.Invoke(this, EventArgs.Empty);

        public class AddBoekICommand : ICommand
        {
            private AddBoekViewModel boekView;

            public AddBoekICommand(AddBoekViewModel boekView)
            {
                this.boekView = boekView;
                this.boekView.ValueChanged += 
                    (object sender, EventArgs e) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return !string.IsNullOrWhiteSpace(boekView.Tietel.Value)
                    && !string.IsNullOrWhiteSpace(boekView.Skrywer.Value)
                    && !string.IsNullOrWhiteSpace(boekView.Dewey.Value)
                    && boekView.Nommer > 0
                    && boekView.Jaar > 0;
            }

            public void Execute(object parameter) => boekView.AddBoek();
        }
    }
}