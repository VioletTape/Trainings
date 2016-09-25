using System;

namespace GoF_ShowCase.TemplateMethod {
    public class Example {
        public Example() {
            AbstractClass c;

            c = new ConcreteClassA();
            c.TemplateMethod();

            c = new ConcreteClassB();
            c.TemplateMethod();

            // Wait for user 
            Console.Read();
        }
    }
}