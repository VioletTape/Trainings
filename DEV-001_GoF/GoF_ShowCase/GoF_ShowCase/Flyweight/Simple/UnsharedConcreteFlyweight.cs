using System;

namespace GoF_ShowCase.Flyweight.Simple {
    internal class UnsharedConcreteFlyweight : Flyweight {
        public override void Operation(int extrinsicstate) {
            Console.WriteLine("UnsharedConcreteFlyweight: " +
                              extrinsicstate);
        }
    }
}