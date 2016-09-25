using System;

namespace GoF_ShowCase.Facade.SimpleStructure {
    public class Example {
        public Example() {
            var facade = new Facade();

            facade.MethodA();
            facade.MethodB();

            // Wait for user 
            Console.Read();
        }
    }
}