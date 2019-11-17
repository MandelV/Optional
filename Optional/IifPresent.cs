using System;
using System.Collections.Generic;
using System.Text;

namespace Optional
{
    interface IIfPresent<T>
    {
        IOrElse<T> IfPresent(Action consumer);
        IOrElse<T> IfPresent(Action<T> consumer);

    }
}
