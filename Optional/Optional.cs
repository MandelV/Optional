using Optional.Exceptions;
using System;

namespace Optional
{
    /// <summary>
    /// Enable to manage if object is present or not
    /// </summary>
    /// <typeparam name="T">type of wrapped object</typeparam>
    public class Optional<T> : IIfPresent<T>, IOrElse<T>, IDisposable where T : class
    {
        /// <summary>
        /// return true if object is present
        /// </summary>
        public bool IsPresent { get; private set; } = false;
        private T value;
        /// <summary>
        /// Wrapped object
        /// </summary>
        public T Value
        {
            get
            {
                if (!IsPresent) throw new OptionalValueException();

                return value;
            }
            private set => this.value = value;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private Optional(ref T value)
        {
            Value = value;
            IsPresent = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private Optional() { }

        public static implicit operator Optional<T>(T value) => Of(value);
        /// <summary>
        /// Create an instance of Optional with wrapped object
        /// </summary>
        /// <typeparam name="T">type of wrapped object</typeparam>
        /// <param name="value">wrapped object</param>
        /// <returns>Optional</returns>
        public static Optional<T> Of(T value) => new Optional<T>(ref value);

        /// <summary>
        /// Create an instance of empty Optional
        /// </summary>
        /// <returns></returns>
        public static Optional<T> Empty() => new Optional<T>();

        public IOrElse<T> IfPresent(Action consumer)
        {
            if (IsPresent) consumer();

            return this;

        }


        public IOrElse<T> IfPresent(Action<T> consumer)
        {
            if (IsPresent) consumer(Value);

            return this;
        }

        public void OrElse(Action action)
        {
            if (!IsPresent) action();
        }

        public T OrElse(T other)
        {
            if (IsPresent) return Value;

            return other;
        }

        public T OrElseGet(Func<T> other)
        {
            if (!IsPresent) return other();

            return Value;
        }

        public T OrElseThrow<E>(E exception) where E : Exception
        {
            if (IsPresent) return Value;

            throw exception;
        }

        /// <summary>
        /// see IDisposable
        /// Enable to dispose object
        /// </summary>
        public void Dispose()
        {
            Disposing();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Finilize
        /// </summary>
        ~Optional() => Disposing();

        /// <summary>
        /// Manage the disposing process
        /// </summary>
        private void Disposing()
        {
            if (Value is IDisposable disposedValue)
            {
                disposedValue.Dispose();
                IsPresent = false;
            }
        }
    }
}
