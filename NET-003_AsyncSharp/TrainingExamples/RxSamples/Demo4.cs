using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PlayingWithRx {
    internal class Demo4 {
        public static async void Synchronization() {
            ThreadPool.SetMaxThreads(5, 5);
            //var n = new int[] {1, 2, 3};

            var lbl = new Label();
            var sc = SynchronizationContext.Current;
            var frm = new Form {
                                   Controls = {
                                                  lbl
                                              }
                               };
            

            var xs = Observable.Range(0, 10, Scheduler.ThreadPool);
            var n = await xs;
            var res = xs.Sum();

            xs
                .ObserveOn(sc)
                .Subscribe(x => {
                               Thread.Sleep(1000);
                               lbl.Text = "Result is " + x;
                           });

            
        }
    }
}