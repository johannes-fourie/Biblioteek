using System;

namespace Biblioteek.Types
{
    public struct Skrywer
    {
        public Skrywer(string skrywer)
        {
            this.Value = !string.IsNullOrWhiteSpace(skrywer)
                ? skrywer
                : throw new NullReferenceException("Die boek moet 'n skrywer hê.");
        }

        public string Value { get; }

        public override string ToString()
        {
            return this.Value;
        }
    }

    public static class SkrywerExtension
    {
        public static Skrywer ToSkrywer(this string skrywer)
        {
            return new Skrywer(skrywer);
        }
    }
}