using Optional.Exceptions;
using System;

namespace Optional
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Optional<T> : IIfPresent<T>, IOrElse<T>, IDisposable where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsPresent { get; private set; } = false;
        private T value;
        /// <summary>
        /// 
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
        private Optional(T value)
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
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Optional<T> Of(T value) => new Optional<T>(value);

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public void Dispose()
        {
            Disposing();
            GC.SuppressFinalize(this);
        }
        ~Optional()
        {
            Disposing();
        }

        private void Disposing()
        {
            var disposedValue = Value as IDisposable;
            if (disposedValue != null)
            {
                disposedValue.Dispose();
                IsPresent = false;
            }

            
        }
    }
}
