using System;

namespace Biblioteek.Types
{
    public struct Maybe<T>
    {
        private readonly bool hasValue;
        private readonly T value;

        public Maybe(T value)
        {
            this.hasValue = true;
            this.value = value;
        }

        public bool HasValue => this.hasValue;

        public T Value => this.hasValue ? this.value : throw new InvalidOperationException();

        public static implicit operator Maybe<T>(T value) => new Maybe<T>(value);
    }
}