using System;

namespace Biblioteek.Types
{
    public struct Tietel
    {
        public Tietel(string tietel)
        {
            this.Value = !string.IsNullOrWhiteSpace(tietel)
                ? tietel
                : throw new NullReferenceException("Die boek moet 'n tietel hê");
        }

        public string Value { get; }

        public override string ToString()
        {
            return this.Value;
        }
    }

    public static class TietelExtension
    {
        public static Tietel ToTietel(this string tietel)
        {
            return new Tietel(tietel);
        }
    }
}