using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace AsyncProgramming.Demos {
//     public class Demo2ExceptionHandling {
//
//        public Demo2ExceptionHandling() {
//            try {
//            //. . .
//            }
//            catch (AggregateException ae) {
//                ae.Handle(x => {
//                              if (x is InvalidOperationException) {
//                                  // assume we know how to handle it
//                                  Console.WriteLine("Bla-bla-bla");
//                                  return true;
//                              }
//                              return false; // let something else stop an app
//                          });
//            }
//        }
//    }

    public class Service {
        public event Action<Task> EndTask;

        public Task<int> DoTaskAsync() {
            var task = new Task<int>(DoTask5);

            if (EndTask != null) {
                task.ContinueWith(EndTask);
            }

            task.Start();

            return task;
        }

       //  figure 1
        private int DoTask() {
            throw new InvalidProgramException("DoTask Exception");
        }


        // figure 2
        private int DoTask2() {
            for (var i = 0; i < 4; i++) {
                var task = new Task(() => { throw new InvalidProgramException("for"); }
                    );
                task.Start();
            }

            return 5;
        }


        // figure 2.1
        private int DoTask3() {
            for (var i = 0; i < 4; i++) {
                var task = new Task(() => { throw new InvalidProgramException("for"); }
                    , TaskCreationOptions.AttachedToParent // do not forget
                    );
                task.Start();
            }
            return 5;
        }


        // figure 2.2
        private int DoTask4() {
            var tasks = new List<Task>();
            for (var i = 0; i < 4; i++) {
                var task = new Task(() => { throw new InvalidProgramException("for"); }
                    );
                task.Start();
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray()); // alternative in some cases to AttachedToParent
            return 5;
        }
         
        // figure 3
        private int DoTask5() {
            var tasks = new List<Task>();
            for (var i = 0; i < 4; i++) {
                var task = new Task(() => {
                                        var t = new Task(
                                            () => { throw new InvalidOperationException("operation"); }
                                            , TaskCreationOptions.AttachedToParent);
                                        t.Start();
//                                        t.Wait(); // do not use
                                        throw new InvalidProgramException("for");
                                    }
                                    , TaskCreationOptions.AttachedToParent
                    );
                task.Start();
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            return 5;
        }

    }

    public class Model {
        private readonly Service service;
        public string result;
        public string ExceptionText;

        public Model() {
            service = new Service();
        }

        public void Act() {
            service.EndTask += EndTask4;
            service.DoTaskAsync();
        }


        // figure 1.0.0
        private void EndTask1(Task obj) {
            var task = (Task<int>) obj;
            result = "isFaulted:" + task.IsFaulted;

        }

        // figure 1.0.1
        private void EndTask2(Task obj) {
            var task = ((Task<int>) obj);
            result = "isFaulted:" + task.IsFaulted;
            if (task.IsFaulted)
                ExceptionText = obj.Exception.ExploreMessages();
         }


        // figure 1.1.0
        private void EndTask3(Task obj) {
            var task = ((Task<int>) obj);
            var s = task.Result;
            result = "isFaulted:" + task.IsFaulted;
            if (task.IsFaulted)
                ExceptionText = obj.Exception.ExploreMessages();
        }

        // figure 1.1.1
        private void EndTask4(Task obj) {
            try {
                var task = ((Task<int>) obj);
                result = "isFaulted:" + task.IsFaulted;
                if (task.IsFaulted)
                    ExceptionText = obj.Exception.ExploreMessages();

                var s = task.Result;
            }
            catch (AggregateException e) {
                ExceptionText = obj.Exception.ExploreMessages();
            }
        }
 
    }

    public class Demo5 {
        public void Start() {
            var model = new Model();

            // Act
            model.Act();

             Thread.Sleep(100);
            Console.WriteLine(model.result);
            Console.WriteLine(model.ExceptionText);

        }
    }


    [TestFixture]
    public class Tests {
        [Test]
        public void ShouldBeFaulted() {
            // Arrange
            var model = new Model();

            // Act
            model.Act();
            Thread.Sleep(100);

            // Assert
            model.result.Should().Be("isFaulted:True");
        }

        [Test]
        public void ShouldBeGetExceptionMessage() {
            // Arrange
            var model = new Model();

            // Act
            model.Act();
            Thread.Sleep(100);

            // Assert
            model.ExceptionText
                .Should()
                .Be("Type:System.InvalidProgramException   Message:DoTask Exception\r\n\r\n");
        }
    }

   

    public static class AggregateExceptionExtensions {
        public static string ExploreMessages(this AggregateException e) {
            var builder = new StringBuilder();

            foreach (var i in e.Flatten().InnerExceptions) {
                builder.AppendLine("Type:" + i.GetType() + "   Message:" + i.Message);
            }
            builder.AppendLine();
            return builder.ToString();
        }
    }
}