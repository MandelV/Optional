using System;

namespace Optional.Exceptions
{
    public class OptionalValueException : Exception
    {
        public OptionalValueException() : base() { }
        public OptionalValueException(string message) : base(message) { }

    }
}
