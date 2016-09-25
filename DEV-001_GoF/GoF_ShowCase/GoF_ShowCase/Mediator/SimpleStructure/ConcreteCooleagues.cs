using System;

namespace GoF_ShowCase.Mediator.SimpleStructure {
    internal class ConcreteColleague1 : Colleague {
        public ConcreteColleague1(Mediator mediator)
            : base(mediator) {}

        public void Send(string message) {
            mediator.Send(message, this);
        }

        public void Notify(string message) {
            Console.WriteLine("Colleague1 gets message: " + message);
        }
    }

    internal class ConcreteColleague2 : Colleague {
        public ConcreteColleague2(Mediator mediator)
            : base(mediator) {}

        public void Send(string message) {
            mediator.Send(message, this);
        }

        public void Notify(string message) {
            Console.WriteLine("Colleague2 gets message: " + message);
        }
    }
}