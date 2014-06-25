using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace Commons {
    /// <summary>
    /// 
    /// </summary>
     public class ReadData {
        private readonly ReplaySubject<string> stream = new ReplaySubject<string>();

        public IObservable<string> ReadStream {
            get { return stream; }
        } 

        public string Read(string s) {
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            stream.OnNext(s);
            return s;
        }
    }

    public class ProcessData {
        private readonly ReplaySubject<string> stream = new ReplaySubject<string>();

        public IObservable<string> ProcessedStream {
            get { return stream; }
        } 

        public string Process(string s) {
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();
            stream.OnNext(s);
            return s;
        }
    }

    public class WriteData {
        public void Write(string s) {
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
        }
    }
}