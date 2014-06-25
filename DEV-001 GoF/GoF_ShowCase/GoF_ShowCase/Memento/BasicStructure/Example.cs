using System;

namespace GoF_ShowCase.Memento.BasicStructure {
    public class Example {
        public Example() {
            var o = new Originator();
            o.State = "On";

            // Store internal state
            var c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);

            // Wait for user
            Console.ReadKey();
        }
    }
}