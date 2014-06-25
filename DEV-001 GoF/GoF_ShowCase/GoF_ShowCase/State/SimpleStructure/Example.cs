using System;

namespace GoF_ShowCase.State.SimpleStructure {
    public class Example {
        public Example() {
            // Setup context in a state 
            var c = new Context(new ConcreteStateA());

            // Issue requests, which toggles state 
            c.Request();
            c.Request();
            c.Request();
            c.Request();


            /*
             State: ConcreteStateA
             State: ConcreteStateB
             State: ConcreteStateA
             State: ConcreteStateB
             State: ConcreteStateA
             
             */
            // Wait for user 
            Console.Read();
        }
    }
}