using System;

namespace Biblioteek.Types
{
    public struct Dewey
    {
        public Dewey(string number)
        {
            this.Number = string.IsNullOrWhiteSpace(number)
                ? throw new NullReferenceException("Dewey nommer kan ne leeg wees nie.")
                : number.Trim();
        }

        public string Number { get; }

        public override string ToString()
        {
            return this.Number;
        }
    }

    public static class DeweyExtension
    {
        public static Dewey ToDewey(this string dewey)
        {
            return new Dewey(dewey);
        }
    }
}