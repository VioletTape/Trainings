using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming.Demos {
    public class Demo1Simple {
        private void CounterMethod() {
            for (var i = 0; i < 10; i++) {
                Console.Write(" {0} ", i);
            }
        }

        public void SimpleExplicitCreation() {
            var task = new Task(CounterMethod);

            task.Start();
        }

        public void SimpleImplicitCreation() {
            var taskFactory = new TaskFactory();
            taskFactory
                .StartNew(CounterMethod);
        }

        public void SimpleImplicitCreation2() {
            var task = Task.Factory.StartNew(CounterMethod);
        }

        public void SimpleExplicitCreationWithCreationOptions() {
            var task = new Task(CounterMethod, TaskCreationOptions.LongRunning);
            task.Start();
        }

        public void SimpleImplicitCreationWithCreationOptions() {
            new TaskFactory()
                      .StartNew(CounterMethod, TaskCreationOptions.LongRunning);
        }

        public void SimpleExplicitCreationWithCreationOptionsAttached() {
            var task = new Task(() => {
                                    var subtask = new Task(() => {
                                                               Console.WriteLine("Hey, wait for me!");
                                                               Thread.Sleep(TimeSpan.FromSeconds(2));
                                                               Console.WriteLine("On board!");
                                                           }
                                                           ,TaskCreationOptions.AttachedToParent
                                        );
                                    subtask.Start();

                                    CounterMethod();
                                });

            task.Start();
            task.Wait();

            Console.WriteLine("Counting ends");
        }

        public void SimpleImplicitCreationWithCreationOptionsAttached() {
            var task = new TaskFactory()
                .StartNew(() => {
                              new Task(() => {
                                           Console.WriteLine("Hey, wait for me!");
                                           Thread.Sleep(TimeSpan.FromSeconds(2));
                                           Console.WriteLine("On board!");
                                       }
                                       , TaskCreationOptions.AttachedToParent
                                  )
                                  .Start();

                              CounterMethod();
                          });

            task.Wait();

            Console.WriteLine("Counting ends");
        }
    }
}