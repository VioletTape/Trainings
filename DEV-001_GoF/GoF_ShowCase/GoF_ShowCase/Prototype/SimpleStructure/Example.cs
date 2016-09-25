using System;

namespace GoF_ShowCase.Prototype.SimpleStructure {
    public class Example {
        public Example() {
            // Create two instances and clone each 
            var p1 = new ConcretePrototype1("I");
            var c1 = (ConcretePrototype1) p1.Clone();
            Console.WriteLine("Cloned: {0}", c1.Id);

            var p2 = new ConcretePrototype2("II");
            var c2 = (ConcretePrototype2) p2.Clone();
            Console.WriteLine("Cloned: {0}", c2.Id);

            // Wait for user 
            Console.Read();
        }
    }
}