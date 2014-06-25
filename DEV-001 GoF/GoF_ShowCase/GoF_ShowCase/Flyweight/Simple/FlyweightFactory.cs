using System.Collections;

namespace GoF_ShowCase.Flyweight.Simple {
    internal class FlyweightFactory {
        private readonly Hashtable flyweights = new Hashtable();

        public FlyweightFactory() {
            flyweights.Add("X", new ConcreteFlyweight());
            flyweights.Add("Y", new ConcreteFlyweight());
            flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key) {
            return ((Flyweight) flyweights[key]);
        }
    }
}