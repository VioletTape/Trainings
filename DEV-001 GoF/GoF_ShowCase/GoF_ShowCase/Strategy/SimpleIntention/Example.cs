using System;

namespace GoF_ShowCase.Strategy.SimpleIntention {
    public class Example {
        public Example() {
            Context context;

            // Three contexts following different strategies 
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            // Wait for user 
            Console.Read();
        }
    }
}