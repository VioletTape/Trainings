namespace GoF_ShowCase.Mediator.SimpleStructure {
    internal abstract class Mediator {
        public abstract void Send(string message, Colleague colleague);
    }
}