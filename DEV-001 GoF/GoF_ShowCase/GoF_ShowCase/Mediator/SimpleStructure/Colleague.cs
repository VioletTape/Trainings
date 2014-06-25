namespace GoF_ShowCase.Mediator.SimpleStructure {
    internal abstract class Colleague {
        protected Mediator mediator;

        protected Colleague(Mediator mediator) {
            this.mediator = mediator;
        }
    }
}