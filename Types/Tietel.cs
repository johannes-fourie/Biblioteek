namespace Biblioteek.Types
{
    public static class TietelExtension
    {
        public static Tietel ToTietel(this string tietel) => new Tietel(tietel);        
    }

    public class Tietel : NotifyPropertyChangedBase, IVlaue<string>
    {
        private string value;

        public Tietel()
            :this(string.Empty)
        { }

        public Tietel(string tietel) => this.value = tietel;

        public string Value
        {
            get => this.value;
            set
            {
                this.value = value;
                this.NotifyPropertyChanged();
            }
        }

        public void Reset() => this.Value = string.Empty;

        public override string ToString() => this.Value;
    }
}