using System;

namespace Optional
{
    interface IIfPresent<T>
    {
        IOrElse<T> IfPresent(Action consumer);
        IOrElse<T> IfPresent(Action<T> consumer);

    }
}
