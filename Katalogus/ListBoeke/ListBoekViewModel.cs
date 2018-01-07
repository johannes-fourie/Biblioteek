using Biblioteek.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteek.Katalogus
{
    public class ListBoekViewModel : INotifyPropertyChanged
    {
        private BoekNommer addToList;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BoekNommer AddToList
        {
            get => this.addToList;
            set
            {
                this.addToList = value;
                NotifyPropertyChanged();
                this.AddBoekToList(this.AddToList);
            }
        }

        private void AddBoekToList(BoekNommer addToList)
        {
            var boekInfo = ListBoekModel.GetBoek(addToList);
        }

        public IListBoekModel ListBoekModel { get; set; }

        public void Initialize()
        {
        }
    }
}
