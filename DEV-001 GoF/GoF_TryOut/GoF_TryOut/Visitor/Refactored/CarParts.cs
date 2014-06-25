using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Visitor.Refactored {
    public interface ICarPart {
        decimal Price { get; set; }
        decimal GetFullPrice();

        void Accept(IVisitor visitor);
    }

    public abstract class CompositeNode : ICarPart {
        internal readonly List<ICarPart> CarParts;

        protected CompositeNode() {
            CarParts = new List<ICarPart>();
        }

        public void Add(ICarPart carPart) {
            if (CanAddPart()) {
                CarParts.Add(carPart);
            }
        }

        public virtual bool CanAddPart() {
            return true;
        }

        public decimal Price { get; set; }

        public decimal GetFullPrice() {
            return CarParts.Sum(i => i.GetFullPrice()) + Price;
        }

        public abstract void Accept(IVisitor visitor);
    }

    public abstract class Node : ICarPart {
        public decimal Price { get; set; }

        public decimal GetFullPrice() {
            return Price;
        }

        public abstract void Accept(IVisitor visitor);
    }

    public class Car : CompositeNode {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
            CarParts.ForEach(i => i.Accept(visitor));
        }
    }

    public class Body : CompositeNode {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
            CarParts.ForEach(i => i.Accept(visitor));
        }
    }

    public class Salon : CompositeNode {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
            CarParts.ForEach(i => i.Accept(visitor));
        }
    }

    public class Cockpit : CompositeNode {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
            CarParts.ForEach(i => i.Accept(visitor));
        }
    }

    public class Audio : CompositeNode {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
            CarParts.ForEach(i => i.Accept(visitor));
        }
    }

    public class Reciever : Node {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }

    public class Speakers : Node {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }

    public class Wheel : CompositeNode {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
            CarParts.ForEach(i => i.Accept(visitor));
        }
    }

    public class Engine : CompositeNode {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
            CarParts.ForEach(i => i.Accept(visitor));
        }
    }

    public class ColorType : Node {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }

    public class Tire : Node {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }

    public class Disc : Node {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }

    public class Turbo : Node {
        public override void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }
}