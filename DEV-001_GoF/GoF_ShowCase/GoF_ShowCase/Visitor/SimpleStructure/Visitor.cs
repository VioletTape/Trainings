namespace GoF_ShowCase.Visitor.SimpleStructure {
    internal abstract class Visitor {
        public abstract void VisitConcreteElementA(
            ConcreteElementA concreteElementA);

        public abstract void VisitConcreteElementB(
            ConcreteElementB concreteElementB);

        public abstract void VisitConcreteElementC(ConcreteElementC concreteElementC);
    }
}