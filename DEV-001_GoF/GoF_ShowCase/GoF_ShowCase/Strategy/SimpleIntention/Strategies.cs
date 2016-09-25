using System;

namespace GoF_ShowCase.Strategy.SimpleIntention {

    internal class ConcreteStrategyA : Strategy {
        public override void AlgorithmInterface() {
            Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    internal class ConcreteStrategyB : Strategy {
        public override void AlgorithmInterface() {
            Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    internal class ConcreteStrategyC : Strategy {
        public override void AlgorithmInterface() {
            Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }


}