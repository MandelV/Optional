using System;
using System.Collections.Generic;
using System.Text;

namespace Optional.Exceptions
{
    public class OptionalValueException : Exception
    {
        public OptionalValueException() : base() { }
        public OptionalValueException(string message) : base(message) { }

    }
}
