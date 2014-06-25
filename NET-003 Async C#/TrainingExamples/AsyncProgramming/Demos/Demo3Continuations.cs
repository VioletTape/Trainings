using System;
using System.Threading.Tasks;

namespace AsyncProgramming.Demos {
    public class Demo3Continuations {
        public void Example1() {
            var task = new Task(() => Console.WriteLine("First"));
            task.ContinueWith(t => Console.WriteLine("Second"));
            task.Start();
        }

        public void Example2() {
            new Task(() => Console.WriteLine("First"))
                .ContinueWith(t => Console.WriteLine("Second"))
                .Start();
        }

        public void Example3() {
            var task = new Task<string>(() => "First");
            task.ContinueWith(t => Console.WriteLine(t.Result + " and Second"));
            task.Start();
        }

        public void Example4() {
            var task = new Task<string>(() => { throw new Exception();});
            task.ContinueWith(t => Console.WriteLine(t.Result + " and Second"), TaskContinuationOptions.NotOnFaulted);
            task.ContinueWith(t => Console.WriteLine("Oups.."), TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }
    }
}