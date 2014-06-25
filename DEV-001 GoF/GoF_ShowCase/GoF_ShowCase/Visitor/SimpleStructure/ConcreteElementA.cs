namespace GoF_ShowCase.Visitor.SimpleStructure {
    internal class ConcreteElementA : Element {
        public override void Accept(Visitor visitor) {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA() {}
    }

    internal class ConcreteElementC : Element {
        public override void Accept(Visitor visitor) {
            visitor.VisitConcreteElementC(this);
        }

        public void OperationA() {}
    }
}