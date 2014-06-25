using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming.Demos {
    public class Demo4TaskComposition {
//        public void ContinueWith() {
//            var value = 500;
//            var task = new Task<int>(() => {
//                                         Thread.Sleep(TimeSpan.FromMilliseconds(value));
//                                         Console.WriteLine(1);
//                                         return 1;
//                                     });
//
//               task.ContinueWith(t => {
//                                  Thread.Sleep(TimeSpan.FromMilliseconds(value));
//                                  Console.WriteLine(t.Result + t.Result);
//                                  return t.Result + t.Result;
//                              })
//                .ContinueWith(t => {
//                                  Thread.Sleep(TimeSpan.FromMilliseconds(value));
//                                  Console.WriteLine(t.Result + t.Result);
//                                  return t.Result + t.Result;
//                              })
//                .ContinueWith(t => {
//                                  Thread.Sleep(TimeSpan.FromMilliseconds(value));
//                                  Console.WriteLine(t.Result + t.Result);
//                                  return t.Result + t.Result;
//                              })
//                .ContinueWith(t => {
//                                  Thread.Sleep(TimeSpan.FromMilliseconds(value));
//                                  Console.WriteLine(t.Result + t.Result);
//                                  return t.Result + t.Result;
//                              });
//
//            task.Start();
//        }   
//
//        public void ContinueWithOption() {
//            var task = new Task<int>(() => {
//                                         Thread.Sleep(TimeSpan.FromMilliseconds(1000));
//                                         Console.WriteLine(1);
////                                         throw new Exception();
//                                         return 1;
//                                     });
//
//            task.ContinueWith(t => Console.WriteLine("Ok"), TaskContinuationOptions.OnlyOnRanToCompletion);
//
//            task.ContinueWith(t => Console.WriteLine("Shit happend"), TaskContinuationOptions.OnlyOnFaulted);
//            task.ContinueWith(t => Console.WriteLine("Shit happend"), TaskContinuationOptions.OnlyOnFaulted);
//
//            task.Start();
//        }


        private void Delay(int sec) {
            Thread.Sleep(TimeSpan.FromSeconds(sec));
        }

        public void WaitAll() {
            var timer = Stopwatch.StartNew();

            var tasks = new List<Task>();
            for (var i = 1; i <= 3; i++) {
                var sec = i;
                var task = new Task(() => Delay(sec));
                task.Start();
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Seconds elapsed: " + timer.Elapsed.Seconds);
        }

        public void WaitAny() {
            var timer = Stopwatch.StartNew();

            var tasks = new List<Task>();
            for (var i = 3; i >=1; i--) {
                var sec = i;
                var task = new Task(() => Delay(sec));
                task.Start();
                tasks.Add(task);
            }

            var taskIndex = Task.WaitAny(tasks.ToArray());

            Console.WriteLine("Seconds elapsed: " + timer.Elapsed.Seconds);
            Console.WriteLine("taskIndex " + taskIndex);
        }

        public void WhenAny() {
            var timer = Stopwatch.StartNew();

            var tasks = new List<Task>();
            for (var i = 1; i <= 3; i++) {
                var sec = i;
                var task = new Task(() => Delay(sec));
                task.Start();
                tasks.Add(task);
            }

            Task.WhenAny(tasks.ToArray())
                .Wait();

            Console.WriteLine("Seconds elapsed: " + timer.Elapsed.Seconds);
        }

        public void WhenAll() {
            var timer = Stopwatch.StartNew();

            var tasks = new List<Task>();
            for (var i = 1; i <= 3; i++) {
                var sec = i;
                var task = new Task(() => Delay(sec));
                task.Start();
                tasks.Add(task);
            }

            var taskAll = Task.WhenAll(tasks.ToArray());
                Console.WriteLine("Awaiting...");
            taskAll.Wait();
            Console.WriteLine("Seconds elapsed: " + timer.Elapsed.Seconds);
        }

        public void ContinueWhenAny() {
            var timer = Stopwatch.StartNew();

            var tasks = new List<Task>();
            for (var i = 1; i <= 3; i++) {
                var sec = i;
                var task = new Task(() => Delay(sec));
                task.Start();
                tasks.Add(task);
            }

            var final = new TaskFactory().ContinueWhenAny(tasks.ToArray(),
                                                          t => {
                                                              Delay(1);
                                                              Console.WriteLine("ContinueWhenAny ");
                                                          });

            final.Wait();

            Console.WriteLine("Seconds elapsed: " + timer.Elapsed.Seconds);
        }

       
        public void ContinueWhenAll() {
            var timer = Stopwatch.StartNew();

            var tasks = new List<Task>();
            for (var i = 1; i <= 3; i++) {
                var sec = i;
                var task = new Task(() => Delay(sec));
                task.Start();
                tasks.Add(task);
            }

            var final = new TaskFactory().ContinueWhenAll(tasks.ToArray(),
                                                          t => {
                                                              Delay(1);
                                                              Console.WriteLine("ContinueWhenAll ");
                                                          });

            final.Wait();

            Console.WriteLine("Seconds elapsed: " + timer.Elapsed.Seconds);
        }
    }
}