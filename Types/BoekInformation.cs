namespace Biblioteek.Types
{
    public struct BoekInformation
    {
        public BoekInformation(
            Tietel tietel,
            Skrywer skrywer,
            Genres genre,
            OuderdomsGroepe ouderdomsGroep,
            BoekNommer boekNommer,
            Dewey dewey)
        {
            this.Tietel = tietel;
            this.Skrywer = skrywer;
            this.Genre = genre;
            this.OuderdomsGroep = ouderdomsGroep;
            this.BoekNommer = boekNommer;
            this.Dewey = dewey;
        }

        public BoekNommer BoekNommer { get; }
        public Dewey Dewey { get; }
        public Genres Genre { get; }
        public OuderdomsGroepe OuderdomsGroep { get; }
        public Skrywer Skrywer { get; }
        public Tietel Tietel { get; }

        public override string ToString()
        {
            return $@"[{this.BoekNommer}] {this.Tietel}; {this.Skrywer}; {this.Genre}; {this.OuderdomsGroep}; [{this.Dewey}]";
        }
    }
}