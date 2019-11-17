using System;

namespace Optional
{
    public interface IOrElse<T>
    {
        /// <summary>
        /// If Value not present invoke action
        /// </summary>
        /// <param name="action"></param>
        void OrElse(Action action);
        
        /// <summary>
        /// if value is present return the value otherwise return other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        T OrElse(T other);

        /// <summary>
        /// if value is present return it, otherwise return the result of the invokation of other
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        T OrElseGet(Func<T> other);
        
        /// <summary>
        /// if value is present return it, otherwise throw an exception
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="exception"></param>
        /// <returns></returns>
        T OrElseThrow<E>(E exception) where E : Exception;
    }
}
