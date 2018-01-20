namespace Biblioteek.Types
{
    public class BoekNommer
    {
        public BoekNommer(int jaar, int nommer)
        {
            this.Jaar = jaar;
            this.Nommer = nommer;
        }

        public int Jaar { get; }

        public int Nommer { get; }

        public override bool Equals(object obj)
        {
            var objBoek = obj as BoekNommer;

            return objBoek?.Jaar == this.Jaar && objBoek?.Nommer == this.Nommer;
        }

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString()
        {
            return $@"{this.Jaar}\{this.Nommer}";
        }
    }
}