using Biblioteek.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Biblioteek.Katalogus
{
    public class AddBoekView : INotifyPropertyChanged
    {
        public IAddBoekModel AddBoekModel { get; set; }

        public AddBoekView()
        {
            this.AddBoekCommand = new AddBoekICommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddBoekICommand AddBoekCommand { get; set; }

        private string genre;

        public string Genre
        {
            get => this.genre;

            set
            {
                this.genre = value;
                NotifyPropertyChanged();
            }
        }

        private int jaar;

        public int Jaar
        {
            get => this.jaar;

            set
            {
                this.jaar = value;
                NotifyPropertyChanged();
            }
        }

        private int nommer;

        public int Nommer
        {
            get => this.nommer;

            set
            {
                this.nommer = value;
                NotifyPropertyChanged();
            }
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class AddBoekICommand : ICommand
        {
            private AddBoekView _boekView;

            public AddBoekICommand(AddBoekView boekView)
            {
                _boekView = boekView;
                _boekView.PropertyChanged += BoekViewPropertyChanged;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
                /*
                return !string.IsNullOrWhiteSpace(_boekView.Tietel)
                    && !string.IsNullOrWhiteSpace(_boekView.Skrywer)
                    && _boekView.Nommer > 0
                    && _boekView.Jaar > 0;
    */        
    }

            public void Execute(object parameter)
            {
                throw new NotImplementedException();
            }

            private void BoekViewPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}