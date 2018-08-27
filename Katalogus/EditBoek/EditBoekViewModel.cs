using Biblioteek.Types;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Biblioteek.Katalogus
{
    public class EditBoekViewModel : NotifyPropertyChangedBase
    {
        private BoekInformation boek;
        private string boekSummary;
        private string nommer;

        public EditBoekViewModel()
        {
            this.UpdateBoekCommand = new UpdateBoekICommand(this);

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

        public event EventHandler ValueChanged;

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

        public Skrywer Skrywer { get; private set; }

        public Taal Taal { get; private set; }

        public Tietel Tietel { get; private set; }

        public UpdateBoekICommand UpdateBoekCommand { get; set; }

        public void Initialize()
        {
            this.EditBoekModel.Initialize();
            this.SignalEditBoek.Edit += this.SignalEditBoek_Edit;
        }

        internal void UpdateBoek()
        {
            this.EditBoekModel.UpdateBoek(new BoekInformation(
                this.Tietel,
                this.Skrywer,
                this.Genre.Value,
                this.OuderdomsGroep.Value,
                this.boek.BoekNommer,
                this.Dewey,
                this.Taal.Value));

            SignalEditBoek.FinishedEditing(this.boek.BoekNommer);
        }

        private void Load(BoekNommer nommer)
        {
            var boek = this.EditBoekModel.GetBoek(nommer);
            if (boek.IsSome)
            {
                this.boek = boek.Value;
                this.Tietel.Value = this.boek.Tietel.Value;
                this.Skrywer.Value = this.boek.Skrywer.Value;
                this.Genre.Value = this.boek.Genre;
                this.OuderdomsGroep.Value = this.boek.OuderdomsGroep;
                this.Nommer = this.boek.BoekNommer.ToString();
                this.Dewey.Value = this.boek.Dewey.Value;
                this.Taal.Value = this.boek.Taal;
            }
        }

        private void SignalEditBoek_Edit(object sender, BoekNommer e)
        {
            Load(e);
        }

        private void ValuePropertyChanged(object sender, PropertyChangedEventArgs e) => this.ValueChanged?.Invoke(this, EventArgs.Empty);

        public class UpdateBoekICommand : ICommand
        {
            private EditBoekViewModel editboekView;

            public UpdateBoekICommand(EditBoekViewModel editboekView)
            {
                this.editboekView = editboekView;
                this.editboekView.ValueChanged += (object sender, EventArgs e) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return !string.IsNullOrWhiteSpace(editboekView.Tietel.Value)
                    && !string.IsNullOrWhiteSpace(editboekView.Skrywer.Value);
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