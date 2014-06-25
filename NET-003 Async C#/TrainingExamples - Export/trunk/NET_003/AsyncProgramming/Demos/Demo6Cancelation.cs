using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming.Demos {
    public class Demo6Cancelation {
        private CancellationTokenSource token;

        private void CounterMethod() {
            for (var i = 0; i < 10; i++) {
                if (token.IsCancellationRequested) {
                    return;
                }

                Console.Write(" {0} ", i);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        public void SimpleCancelation() {
            token = new CancellationTokenSource();
            var task = new Task(CounterMethod, token.Token);

            task.Start();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            token.Cancel();

            task.Wait();
        }

        public void SimpleCancelationStates() {
            token = new CancellationTokenSource();
            var task = new Task(CounterMethod, token.Token);

            task.Start();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            token.Cancel();

            task.Wait();

            Console.WriteLine();
            Console.WriteLine("IsCompleted {0}", task.IsCompleted);
            Console.WriteLine("IsCanceled {0}", task.IsCanceled);
            Console.WriteLine("Status {0}", task.Status);
        }


        private void CounterMethod2() {
            for (var i = 0; i < 10; i++) {
                if (token.IsCancellationRequested) {
                    token.Token.ThrowIfCancellationRequested();
                    return;
                }

                Console.Write(" {0} ", i);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        public void CancelationStatesCancel() {
            token = new CancellationTokenSource();
            var task = new Task(CounterMethod2, token.Token);

            task.Start();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            token.Cancel();

            try {
                task.Wait();
            }
            catch (AggregateException ag) {
                Console.WriteLine();
                Console.WriteLine("IsCompleted {0}", task.IsCompleted);
                Console.WriteLine("IsCanceled {0}", task.IsCanceled);
                Console.WriteLine("Status {0}", task.Status);
                Console.WriteLine("Exception {0}", ag.Flatten().InnerExceptions[0].Message);
            }
        }

        public void CancelationStatesCancelWithoutToken() {
            token = new CancellationTokenSource();
            var task = new Task(CounterMethod2);

            task.Start();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            token.Cancel();

            try {
                task.Wait();
            }
            catch (AggregateException ag) {
                Console.WriteLine();
                Console.WriteLine("IsCompleted {0}", task.IsCompleted);
                Console.WriteLine("IsCanceled {0}", task.IsCanceled);
                Console.WriteLine("Status {0}", task.Status); // pay attention
                Console.WriteLine("Exception {0}", ag.Flatten().InnerExceptions[0].Message);
            }
        }

        private void CounterMethod3(CancellationTokenSource tokenSource) {
            for (var i = 0; i < 10; i++) {
                if (tokenSource.IsCancellationRequested) {
                    tokenSource.Token.ThrowIfCancellationRequested();
                    return;
                }

                Console.Write(" {0} ", i);
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }


        public void GroupCancellation() {
            var token1 = new CancellationTokenSource();
            var token2 = new CancellationTokenSource();

            var tokenSource = CancellationTokenSource.CreateLinkedTokenSource(token1.Token, token2.Token);

            var task = new Task(() => CounterMethod3(tokenSource), tokenSource.Token);
            task.Start();

            Thread.Sleep(TimeSpan.FromSeconds(3));

//            token1.Cancel();
            token2.Cancel();

            try {
                task.Wait();
            }
            catch (AggregateException ag) {
                Console.WriteLine();
                Console.WriteLine("IsCompleted {0}", task.IsCompleted);
                Console.WriteLine("IsCanceled {0}", task.IsCanceled);
                Console.WriteLine("Status {0}", task.Status);
                Console.WriteLine("Exception {0}", ag.Flatten().InnerExceptions[0].Message);
                Console.WriteLine("Token 1 cancel requested {0}", token1.IsCancellationRequested);
                Console.WriteLine("Token 2 cancel requested {0}", token2.IsCancellationRequested);
            }
        }
    }
}