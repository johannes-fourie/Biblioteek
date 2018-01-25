using System;

namespace Biblioteek.Types
{
    public class Maybe<T>
    {
        private readonly bool isSome;
        private readonly T value;

        public Maybe(T value)
        {
            this.isSome = true;
            this.value = value;
        }

        private Maybe()
        {
            this.isSome = false;
            this.value = default;
        }

        public static Maybe<T> None()
        {
            return new Maybe<T>();
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