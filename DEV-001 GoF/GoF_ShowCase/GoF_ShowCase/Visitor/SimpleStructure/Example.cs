using System;

namespace GoF_ShowCase.Visitor.SimpleStructure {
    public class Example {
        public Example() {
            // Setup structure 
            var o = new ObjectStructure();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteElementB());

            // Create visitor objects 
            var v1 = new ConcreteVisitor1();
            var v2 = new ConcreteVisitor2();

            // Structure accepting visitors 
            o.Accept(v1);
            o.Accept(v2);

            // Wait for user 
            Console.Read();

            /*
             ConcreteElementA visited by ConcreteVisitor1
             ConcreteElementB visited by ConcreteVisitor1
             * 
             ConcreteElementA visited by ConcreteVisitor2
             ConcreteElementB visited by ConcreteVisitor2
             
             */
        }
    }
}