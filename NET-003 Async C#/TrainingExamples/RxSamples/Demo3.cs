using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithRx {
    internal class Demo3 {
        private static int LongRunningFunc(string s) {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return s.Length;
        }

        public static void FromAsyncPattern() {
            Func<string, int> longRunningFunc = LongRunningFunc;

            var funcHelper =
                Observable.FromAsyncPattern<string, int>(longRunningFunc.BeginInvoke, longRunningFunc.EndInvoke);

            var xs = funcHelper("Hello, String");
            xs.Subscribe(x => Console.WriteLine("Length is " + x));
        }

        public static void TaskBasedAsynchrony() {
            Func<string, int> longRunningFunc = LongRunningFunc;

            var s = "Hello, String";

            Task<int> task = longRunningFunc.ToTask(s);
            task.Wait();
            Console.WriteLine("Length is " + task.Result);
        }

        public static void FromTask() {
            Func<string, int> longRunningFunc = LongRunningFunc;

            var s = "Hello, String";

            IObservable<int> xs = longRunningFunc.ToTask(s).ToObservable();

            xs.Subscribe(x => Console.WriteLine("Length is " + x),
                         () => Console.WriteLine("Task is finished"));
        }
    }

    internal static class FuncExtensions {
        internal static Task<int> ToTask(this Func<string, int> func, string s) {
            return Task<int>.Factory.FromAsync(
                func.BeginInvoke, func.EndInvoke, s, null);
        }
    }
}