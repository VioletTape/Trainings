using System;
using System.Reactive.Subjects;

namespace RxSamples {
    public class Demo0 {
        public void SubjectExample() {
            var subject = new Subject<string>();

            WriteStreamToConsole(subject);
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnNext("c");
        }

        public void SubjectExample1(){
            var subject = new Subject<string>();

            subject.OnNext("a");
            WriteStreamToConsole(subject);
            subject.OnNext("b");
            subject.OnNext("c");
        }

        public void ReplaySubject2() {
            var subject = new ReplaySubject<string>();

            subject.OnNext("a");
            WriteStreamToConsole(subject);

            subject.OnNext("b");
            subject.OnNext("c");
        }

        public void BehaviorSubject1() {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            WriteStreamToConsole(subject);
            subject.OnNext("c");
            subject.OnNext("d");
            subject.OnCompleted();
            WriteStreamToConsole(subject);
        }

        public void AsyncSubject() {
            var subject = new AsyncSubject<string>();

            subject.OnNext("a");
            WriteStreamToConsole(subject);
            subject.OnNext("b");
            subject.OnNext("c");

            subject.OnCompleted();
        }

        public void Unsbuscribing() {
            var values = new Subject<int>();
            var firstSubscription = values.Subscribe(value =>
                                                     Console.WriteLine("1st subscription received {0}", value));
            var secondSubscription = values.Subscribe(value =>
                                                      Console.WriteLine("2nd subscription received {0}", value));
            values.OnNext(0);
            values.OnNext(1);
            values.OnNext(2);
            values.OnNext(3);
            firstSubscription.Dispose();
            Console.WriteLine("Disposed of 1st subscription");
            values.OnNext(4);
            values.OnNext(5);
        }

        private static void WriteStreamToConsole(IObservable<string> stream) {
            stream.Subscribe(Console.WriteLine);
        }
    }
}