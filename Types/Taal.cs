using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Biblioteek.Types
{
    public enum Tale
    {
        English,
        Afrikaans
    }

    public class Taal : NotifyPropertyChangedBase, IVlaue<Tale>
    {
        public Taal()
            :this(default)
        { }

        public Taal(Tale taal)
        {
            this.NameValues = new List<TaalNameValue>();
            this.Value = taal;            

            foreach (var t in Enum.GetValues(typeof(Tale)).Cast<Tale>())
            {
                var valuePare = new TaalNameValue()
                {
                    Taal = t,
                    Name = t.ToString().Replace('_', ' '),
                    Set = t == Value
                };

                valuePare.TaalSet += (object sender, Tale e) => Value = e;
                this.NameValues.Add(valuePare);
            }
        }

        public List<TaalNameValue> NameValues { get; }

        private Tale value;

        public Tale Value
        {
            get => this.value;
            set
            {
                this.value = value;
                this.NameValues.Where(nv => nv.Taal == this.value && !nv.Set).ToList().ForEach(nv => nv.Set = true);
                this.NotifyPropertyChanged();
            }
        }

        public void Reset() => this.Value = default;
    }

    public class TaalNameValue : INotifyPropertyChanged
    {
        private bool set;

        public event EventHandler<Tale> TaalSet;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public bool Set
        {
            get { return set; }
            set
            {
                set = value;
                NotifyPropertyChanged();
                if (value)
                {
                    TaalSet?.Invoke(this, Taal);
                }
            }
        }

        public Tale Taal { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}