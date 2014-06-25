using System;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PlayingWithRx {
    internal class CustomObserver : IObserver<string> {
        public void OnNext(string value) {
            Console.WriteLine("CustomObserver.OnNext: {0}", value);
        }

        public void OnError(Exception error) {
            throw new NotImplementedException();
        }

        public void OnCompleted() {
            throw new NotImplementedException();
        }
    }

    internal class Demo2 {
        public static void TextBoxDemo() {
            var textBox = new TextBox();
            var frm = new Form {
                                   Controls = {
                                                  textBox
                                              }
                               };

            var xs1 = (from e in Observable.FromEventPattern(textBox, "TextChanged")
                       let txt = (TextBox) e.Sender
                       select txt.Text);

            var xs = xs1
                .Throttle(TimeSpan.FromMilliseconds(200))
                .DistinctUntilChanged();

            var disposable = xs.Subscribe(Console.WriteLine);

            Application.Run(frm);
        }


        public static void MouseMoveDemo() {
            var frm = new Form();
            var xs = from e in Observable.FromEventPattern<MouseEventArgs>(frm, "MouseMove")
                     let l = e.EventArgs.Location
                     where l.X == l.Y
                     select l;

//            xs.Subscribe(
//                l => Console.WriteLine("From simple subscriber " + l));
            xs.Subscribe(l =>
                             {
                                 Console.WriteLine("Begin...");
                                 Console.WriteLine(l);
                                 Thread.Sleep(200);
                                 Console.WriteLine("End...");
                             });
            Application.Run(frm);
        }
    }
}