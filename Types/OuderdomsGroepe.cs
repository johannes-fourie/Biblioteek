using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Biblioteek.Types
{
    public enum OuderdomsGroepe
    {
        Kleuter,
        Tiener
    }

    public class OuderdomsGroep : INotifyPropertyChanged
    {
        public OuderdomsGroep(OuderdomsGroepe ouderdomsGroepe)
        {
            this.NameValues = new List<OuderdomsGroepNameValue>();
            this.Value = ouderdomsGroepe;

            foreach (var o in Enum.GetValues(typeof(OuderdomsGroepe)).Cast<OuderdomsGroepe>())
            {
                var valuePare = new OuderdomsGroepNameValue()
                {
                    OuderdomsGroep = o,
                    Name = o.ToString().Replace('_', ' '),
                    Set = o == Value
                };

                valuePare.OuderdomsGroepSet += OuderdomsGropeSet;
                this.NameValues.Add(valuePare);
            }
        }

        public void OuderdomsGropeSet(object sender, OuderdomsGroepe ouderdomsGroep)
        {
            if (!updatingValue)
                Value = ouderdomsGroep;
        }

        public List<OuderdomsGroepNameValue> NameValues { get; }

        private OuderdomsGroepe value;

        private bool updatingValue;

        public OuderdomsGroepe Value
        {
            get => this.value;
            set
            {
                this.updatingValue = true;
                this.value = value;

                this.NameValues
                    .Where(nv => nv.OuderdomsGroep == this.value)
                    .ToList()
                    .ForEach(nv => nv.Set = true);
                this.updatingValue = false;
                this.NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class OuderdomsGroepNameValue : INotifyPropertyChanged
    {
        private bool set;

        public event EventHandler<OuderdomsGroepe> OuderdomsGroepSet;

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
                    OuderdomsGroepSet?.Invoke(this, OuderdomsGroep);
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public OuderdomsGroepe OuderdomsGroep { get; set; }
    }

}