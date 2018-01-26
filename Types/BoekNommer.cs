using System;

namespace Biblioteek.Types
{
    public class BoekNommer : IComparable
    {
        public BoekNommer(int jaar, int nommer)
        {
            this.Jaar = jaar;
            this.Nommer = nommer;
        }

        public int Jaar { get; }

        public int Nommer { get; }

        public int CompareTo(object obj)
        {
            int result;
            var boekNommer = obj as BoekNommer;
            if (boekNommer is null)
                result = 1;
            else if (this.Jaar < boekNommer.Jaar)
                result = -1;
            else if (this.Jaar > boekNommer.Jaar)
                result = 1;
            else if (this.Nommer < boekNommer.Nommer)
                result = -1;
            else if (this.Nommer > boekNommer.Nommer)
                result = 1;
            else
                result = 0;

            return result;
        }

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