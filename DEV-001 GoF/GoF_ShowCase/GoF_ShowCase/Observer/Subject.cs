using System.Collections;

namespace GoF_ShowCase.Observer {
    internal abstract class Subject {
        private readonly ArrayList observers = new ArrayList();

        public void Attach(Observer observer) {
            observers.Add(observer);
        }

        public void Detach(Observer observer) {
            observers.Remove(observer);
        }

        public void Notify() {
            foreach (Observer o in observers) {
                o.Update();
            }
        }
    }
}