using System;

namespace GoF_ShowCase.Builder.SimpleStructure {
    public class Example {
        public Example() {
            // Create director and builders 
            var director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            // Construct two products 
            director.Construct(b1);
            var p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            var p2 = b2.GetResult();
            p2.Show();

            // Wait for user 
            Console.Read();
        }
    }
}