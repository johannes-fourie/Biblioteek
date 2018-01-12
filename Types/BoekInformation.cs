namespace Biblioteek.Types
{
    public class BoekInformation
    {
        public BoekInformation(
            Tietel tietel,
            Skrywer skrywer,
            Genres genre,
            OuderdomsGroepe ouderdomsGroep,
            BoekNommer boekNommer)
        {
            this.Tietel = tietel;
            this.Skrywer = skrywer;
            this.Genre = genre;
            this.OuderdomsGroep = ouderdomsGroep;
            this.BoekNommer = boekNommer;
        }

        public BoekNommer BoekNommer { get; }
        public Genres Genre { get; }
        public OuderdomsGroepe OuderdomsGroep { get; }
        public Skrywer Skrywer { get; }
        public Tietel Tietel { get; }

        public override string ToString()
        {
            return $@"{this.Tietel}; {this.Skrywer}; {this.BoekNommer}";
        }
    }
}