using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Biblioteek
{
    public class AddBoekView : INotifyPropertyChanged
    {
        private AddBoekData _data = new AddBoekData();

        public AddBoekView()
        {
            this.AddBoekCommand = new AddBoekICommand(this);

            _data = new AddBoekData()
            {
                Jaar = (DateTime.Now.Year % 1000) % 100
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public AddBoekICommand AddBoekCommand { get; set; }

        public string Genre
        {
            get => _data.Genre;

            set
            {
                _data.Genre = value;
                NotifyPropertyChanged();
            }
        }

        public int Jaar
        {
            get => _data.Jaar;

            set
            {
                _data.Jaar = value;
                NotifyPropertyChanged();
            }
        }

        public int Nommer
        {
            get => _data.Nommer;

            set
            {
                _data.Nommer = value;
                NotifyPropertyChanged();
            }
        }

        public string OurderdomsGroep
        {
            get => _data.OurderdomsGroep;

            set
            {
                _data.OurderdomsGroep = value;
                NotifyPropertyChanged();
            }
        }

        public string Skrywer
        {
            get => _data.Skrywer;

            set
            {
                _data.Skrywer = value;
                NotifyPropertyChanged();
            }
        }

        public string Tietel
        {
            get => _data.Tietel;

            set
            {
                _data.Tietel = value;
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
                return !string.IsNullOrWhiteSpace(_boekView.Tietel)
                    && !string.IsNullOrWhiteSpace(_boekView.Skrywer)
                    && _boekView.Nommer > 0
                    && _boekView.Jaar > 0;
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