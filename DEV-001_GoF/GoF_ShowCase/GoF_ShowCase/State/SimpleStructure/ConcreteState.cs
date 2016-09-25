namespace GoF_ShowCase.State.SimpleStructure {
    internal class ConcreteStateA : State {
        public override void Handle(Context context) {
            context.State = new ConcreteStateB();
        }
    }

    internal class ConcreteStateB : State {
        public override void Handle(Context context) {
            context.State = new ConcreteStateA();
        }
    }
}