namespace GoF_ShowCase.Visitor.SimpleStructure {
    internal abstract class Element {
        public abstract void Accept(Visitor visitor);
    }
}