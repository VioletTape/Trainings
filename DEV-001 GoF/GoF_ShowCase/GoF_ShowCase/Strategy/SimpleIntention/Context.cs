namespace GoF_ShowCase.Strategy.SimpleIntention {
    internal class Context {
        private readonly Strategy strategy;

        public Context(Strategy strategy) {
            this.strategy = strategy;
        }

        public void ContextInterface() {
            strategy.AlgorithmInterface();
        }
    }
}