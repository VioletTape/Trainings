namespace GoF_ShowCase.Command.Simple {
    internal abstract class Command {
        protected Receiver Receiver;

        protected Command(Receiver receiver) {
            this.Receiver = receiver;
        }

        public abstract void Execute();
    }
}