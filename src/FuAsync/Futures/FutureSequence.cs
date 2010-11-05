using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuAsync.Futures
{
    public class FutureSequence : IFuture
    {
        public IEnumerator<IFuture> enumerator { get; set; }
        public Action continuation { get; set; }

        public FutureSequence(IEnumerator<IFuture> enumerator)
        {
            this.enumerator = enumerator;
        }

        public void Await(Action continuation)
        {
            this.continuation = continuation;
            OnChildCompleted();
        }

        private void OnChildCompleted()
        {
            if (enumerator.MoveNext())
            {
                enumerator.Current.Await(OnChildCompleted);
            }
            else
            {
                if (continuation != null)
                    continuation();
            }

        }
    }
}
