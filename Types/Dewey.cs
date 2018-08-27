namespace Biblioteek.Types
{
    public static class DeweyExtension
    {
        public static Dewey ToDewey(this string dewey)
        {
            return new Dewey(dewey);
        }
    }

    public class Dewey : NotifyPropertyChangedBase, IVlaue<string>
    {
        private string value;

        public Dewey()
            : this(string.Empty)
        { }

        public Dewey(string number) => this.value = number;

        public string Value
        {
            get => this.value;

            set
            {
                this.value = value;
                NotifyPropertyChanged();
            }
        }

        public void Reset() => this.Value = string.Empty;

        public override string ToString() => this.Value;
    }
}