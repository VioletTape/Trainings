using System;

namespace GoF_ShowCase.Visitor.SimpleStructure {
    internal class ConcreteVisitor2 : Visitor {
        public override void VisitConcreteElementA(
            ConcreteElementA concreteElementA) {
            Console.WriteLine("{0} visited by {1}",
                              concreteElementA.GetType().Name, GetType().Name);
        }

        public override void VisitConcreteElementB(
            ConcreteElementB concreteElementB) {
            Console.WriteLine("{0} visited by {1}",
                              concreteElementB.GetType().Name, GetType().Name);
        }

        public override void VisitConcreteElementC(ConcreteElementC concreteElementC) {
        
        }
    }
}