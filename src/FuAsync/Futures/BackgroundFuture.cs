using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FuAsync.Futures
{
    public class BackgroundFuture<T> : IFuture<T>
    {
        public BackgroundFuture(Func<T> work)
        {
            this.work = work;
        }

        public Func<T> work { get; set; }
        public T Value { get; set; }

        public void Await(Action continuation)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) => { Value = work(); };
            worker.RunWorkerCompleted += (sender, e) => { continuation(); };
            worker.RunWorkerAsync();
        }
    }
}
