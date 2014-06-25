using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming.Demos {
    public class Demo2TaskCompletionSource {
        public void ResultUsage() {
            var task = new Task<string>(() => {
                                            Thread.Sleep(TimeSpan.FromSeconds(2));
                                            return "Done";
                                        });

            task.Start();
            task.Wait();

            Console.WriteLine("Result {0}",task.Result);
            Console.WriteLine("IsCompleted {0}",task.IsCompleted);
            Console.WriteLine("Status {0}",task.Status);
        }




        public void ResultIsBlocking() {
            var task = new Task<string>(() => {
                                            Thread.Sleep(TimeSpan.FromSeconds(2));
                                            return "Done";
                                        });

            task.Start();
            Console.WriteLine("Result {0}",task.Result);
            Console.WriteLine("IsCompleted {0}",task.IsCompleted);

            task.Wait();

            Console.WriteLine("Result {0}",task.Result);
            Console.WriteLine("IsCompleted {0}",task.IsCompleted);
            Console.WriteLine("Status {0}",task.Status);
        }

        public void IsCompleted__Guess() {
            var task = new Task<string>(() => {
                                            Thread.Sleep(TimeSpan.FromSeconds(2));
                                            return "Done";
                                        });

            task.Start();
            Console.WriteLine("IsCompleted {0}",task.IsCompleted);

            task.Wait();

            Console.WriteLine("Result {0}",task.Result);
            Console.WriteLine("IsCompleted {0}",task.IsCompleted);
            Console.WriteLine("Status {0}",task.Status);
        }
    }
}