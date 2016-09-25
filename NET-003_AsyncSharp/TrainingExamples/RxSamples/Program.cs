using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;
using PlayingWithRx;

namespace RxSamples {
    internal class Program {
        private static void Main(string[] args) {
            Demo2.MouseMoveDemo();
                
            Console.ReadLine();
        }


























        public static void FormExample() {
            var lbl = new Label();
            var frm = new Form
            {
                Controls = {
                                                  lbl
                                              }
            };

            Synchronization(lbl);
            Application.Run(frm);
        }

        public static async void Synchronization(Label lbl) {
            ThreadPool.SetMaxThreads(5, 5);
            //var n = new int[] {1, 2, 3};

          
//            var sc = SynchronizationContext.Current;
          
            

            var xs = Observable.Range(0, 10, TaskPoolScheduler.Default);
            var n = await xs;
            var res = xs.Sum();

            xs
//                .ObserveOn(sc)
                .Subscribe(x => {
//                               Thread.Sleep(1000);
                               lbl.Text = "Result is " + x;
                           });

            
        }
    }
}