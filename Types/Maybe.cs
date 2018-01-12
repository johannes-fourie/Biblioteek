using System;

namespace Biblioteek.Types
{
    public struct Maybe<T>
    {
        private readonly bool isSome;
        private readonly T value;

        public Maybe(T value)
        {
            this.isSome = true;
            this.value = value;
        }

        public bool IsSome => this.isSome;

        public T Value => this.isSome ? this.value : throw new InvalidOperationException();

        public static implicit operator Maybe<T>(T value) => new Maybe<T>(value);

        public Maybe<T> IfSome(Action<Maybe<T>> action)
        {
            action(this);
            return this;
        }
    }
}