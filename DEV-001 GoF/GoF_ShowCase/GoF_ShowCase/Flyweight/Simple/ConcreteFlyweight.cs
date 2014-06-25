using System;

namespace GoF_ShowCase.Flyweight.Simple {
    internal class ConcreteFlyweight : Flyweight {
        public override void Operation(int extrinsicstate) {
            Console.WriteLine("ConcreteFlyweight: " + extrinsicstate);
        }
    }
}