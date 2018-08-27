namespace Biblioteek.Types
{
    public static class SkrywerExtension
    {
        public static Skrywer ToSkrywer(this string skrywer) => new Skrywer(skrywer);
    }

    public class Skrywer : NotifyPropertyChangedBase, IVlaue<string>
    {
        private string value;

        public Skrywer() => this.value = string.Empty;

        public Skrywer(string skrywer) => this.value = skrywer;

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