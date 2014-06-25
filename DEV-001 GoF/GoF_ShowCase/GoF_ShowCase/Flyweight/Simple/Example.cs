using System;

namespace GoF_ShowCase.Flyweight.Simple {
    public class Example {
        public Example() {
            // Arbitrary extrinsic state 
            var extrinsicstate = 22;

            var f = new FlyweightFactory();

            // Work with different flyweight instances 
            var fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            var fy = f.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            var fz = f.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);

            var uf = new UnsharedConcreteFlyweight();

            uf.Operation(--extrinsicstate);

            // Wait for user 
            Console.Read();
        }
    }
}