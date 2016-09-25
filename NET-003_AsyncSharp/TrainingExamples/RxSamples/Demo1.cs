using System;
using System.Reactive.Linq;
using System.Threading;

namespace PlayingWithRx {
    internal class Demo1 {
        public static void Start() {
            MoreComplexGenerateWithRandom();
            Console.ReadLine();
        }

        public static void SimpleGenerate() {
            var xs = Observable.Generate( // for (
                0, // i = 0;
                x => x < 5, // i < 10;
                x => {
                    if (x > 5) {
//                        throw new Exception("Ooops!!");
                    }
                    return x + 1;
                }, // i++
                x => x, // result
                x => TimeSpan.FromSeconds(1)
                );


            var d = xs.Subscribe(
                x => Console.WriteLine(x),
                e => Console.WriteLine(e),
                () => Console.WriteLine("Done")
                );

            Console.WriteLine("Waiting for user input");

            string s = null;

            while (s != "q") {
                s = Console.ReadLine();
                Console.WriteLine("User input is " + s);
            }

            Console.WriteLine("Unsubscribing...");
            d.Dispose();
        }

        public static void GenerateWithRandom() {
            var rnd = new Random(42);
            var xs = Observable.Generate(
                0,
                x => true, // never ends
                x => {
                    //                    Console.WriteLine("Increment ");
                    return rnd.Next()%5; //Returns the remainder of one expression divided by another.
                },
                x => x,
                x => TimeSpan.FromMilliseconds(500));
//            .DistinctUntilChanged();
            var xs2 = xs.DistinctUntilChanged();

            xs.Subscribe(x => Console.WriteLine("All: " + x));
//            xs2.Subscribe(x => Console.WriteLine("Only unique: " + x));
        }

        public static void MoreComplexGenerateWithRandom() {
            var rnd = new Random(42);
            var xs = Observable.Generate(
                0,
                x => true,
                x => rnd.Next()%5,
                x => x,
                x => TimeSpan.FromMilliseconds(100))
                               //.DistinctUntilChanged()
                               .Buffer(9)
                               .Do(z => Console.WriteLine(""))
                               .Subscribe(x => {
//                                   Console.Write(string.Join(" ", x));
                                   x.ToObservable().Subscribe(v => Console.Write(v + " "));
                               });
        }
    }
}