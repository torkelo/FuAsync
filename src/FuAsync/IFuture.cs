using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuAsync
{
    public interface IFuture
    {
        void Await(Action continuation);
    }

    public interface IFuture<out T> : IFuture
    {
        T Value { get; }
    }
}
