using Optional.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optional
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Optional<T> : IIfPresent<T>, IOrElse<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsPresent { get; private set; } = false;
        
        /// <summary>
        /// 
        /// </summary>
        public T Value
        {
            get {
                if (!IsPresent) throw new OptionalValueException();

                return Value;
            }
            private set => Value = value;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public Optional(T value)
        {
            Value = value;
            IsPresent = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public Optional() { }


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
    }
    /// <summary>
    /// 
    /// </summary>
    public static class Optional
    {
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Optional<T> Of<T>(T value) => new Optional<T>(value);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Optional<object> Empty() => new Optional<object>();
    }
}
