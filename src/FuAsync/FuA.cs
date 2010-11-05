using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FuAsync.Futures;

namespace FuAsync
{
    public static class FuA
    {
        public static IFuture<T> DoInBackground<T>(Func<T> work)
        {
            return new BackgroundFuture<T>(work);
        }
    }
}
