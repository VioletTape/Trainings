using System;
using System.Threading.Tasks;

namespace Commons {
    public class EmptyService {
        public void StartPhase() {
            Base(1);
        }

        public void MiddlePhase() {
            Base(2);
        }

        public void FinalPhase() {
            Base(1);
        }

        private void Base(int seconds) {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }
    }
}