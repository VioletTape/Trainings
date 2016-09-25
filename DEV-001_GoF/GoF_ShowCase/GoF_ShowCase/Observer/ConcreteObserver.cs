using System;

namespace GoF_ShowCase.Observer {
    internal class ConcreteObserver : Observer {
        private readonly string name;
        private string observerState;

        public ConcreteSubject Subject { get; set; }

        public ConcreteObserver(ConcreteSubject subject, string name) {
            Subject = subject;
            this.name = name;
        }

        public override void Update() {
            observerState = Subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}",
                              name, observerState);
        }
    }
}