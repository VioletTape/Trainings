using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming.Demos {
    public class Demo7SyncAsync {
       
    }

    public class Model7SyncAsync {
        public async void SomeAction() {
            Console.WriteLine("Start actions");
            var task = new Task(() => {
                                    Console.WriteLine("DoLongWork entered");
                                    Thread.Sleep(2000);
                                    Console.WriteLine("DoLongWork ended");
                                });
            task.Start();
            await task;

            Console.WriteLine("End actions");
        }
    }

    #region More traditional way

    public class Model2 {
        public void SomeAction() {
            Console.WriteLine("Start actions");
            var task = new Task(() => {
                                    Console.WriteLine("DoLongWork enterd");
                                    Thread.Sleep(2000);
                                    Console.WriteLine("DoLongWork ended");
                                });
            task.ContinueWith(SomeActionEnd);
            task.Start();
        }

        public void SomeActionEnd(Task task) {
            Console.WriteLine("End actions");
        }
    }

    #endregion
}