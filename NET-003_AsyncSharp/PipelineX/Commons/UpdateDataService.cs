using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace Commons {
    public class UpdateDataService {
        public string StartPhase(string s) {
            s += "s";
            Base(1);
            return s;
        }

        public string MiddlePhase(string s) {
            s += "m";
            Base(2);
            return s;

        }

        public string FinalPhase(string s) {
            s += "f";
            Base(1);
            return s;

        }

        private void Base(int seconds) {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }
    }

   
}