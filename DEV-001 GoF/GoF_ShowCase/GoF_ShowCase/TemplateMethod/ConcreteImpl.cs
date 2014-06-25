using System;

namespace GoF_ShowCase.TemplateMethod {
    internal class ConcreteClassA : AbstractClass {
        public override void PrimitiveOperation1() {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2() {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }

    internal class ConcreteClassB : AbstractClass {
        public override void PrimitiveOperation1() {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2() {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
        }
    }
}