using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GoF_TryOut.Visitor.Straight {
    public interface ICarPart {
        decimal Price { get; set; }
        decimal GetFullPrice();
    }

    public abstract class CompositeNode : ICarPart {
        private readonly List<ICarPart> carParts;

        public ReadOnlyCollection<ICarPart> Parts {
            get {
                return carParts.AsReadOnly();
            }
        } 

        protected CompositeNode() {
            carParts = new List<ICarPart>();
        }

        public void Add(ICarPart carPart) {
            if (CanAddPart()) {
                carParts.Add(carPart);
            }
        }

        public virtual bool CanAddPart() {
            return true;
        }

        public decimal Price { get; set; }

        public decimal GetFullPrice() {
            return carParts.Sum(i => i.GetFullPrice()) + Price;
        }
    }

    public abstract class Node : ICarPart {
        public decimal Price { get; set; }

        public decimal GetFullPrice() {
            return Price;
        }
    }

    public class Car : CompositeNode {}

    public class Body : CompositeNode {}

    public class Salon : CompositeNode {}

    public class Cockpit : CompositeNode {}

    public class Audio : CompositeNode {}

    public class Reciever : Node {}

    public class Speakers : Node {}

    public class Wheel : CompositeNode {}

    public class Engine : CompositeNode {}

    public class ColorType : Node {}

    public class Tire : Node {}

    public class Disc : Node {}

    public class Turbo : Node {}
}