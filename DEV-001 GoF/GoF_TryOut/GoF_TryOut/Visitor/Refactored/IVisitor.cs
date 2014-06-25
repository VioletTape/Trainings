namespace GoF_TryOut.Visitor.Refactored {
    public interface IVisitor {
        void Visit(Car car);
        void Visit(Body body);
        void Visit(Salon salon);
        void Visit(Cockpit cockpit);
        void Visit(Audio audio);
        void Visit(Reciever reciever);
        void Visit(Speakers speakers);
        void Visit(Wheel wheel);
        void Visit(Engine engine);
        void Visit(ColorType colorType);
        void Visit(Tire tire);
        void Visit(Disc disc);
        void Visit(Turbo turbo);
    }

    public class SummarizeCostVisitor : IVisitor {
        public decimal TotalPrice { get; private set; }

        public void Visit(Car car) {
            TotalPrice += car.Price;
        }

        public void Visit(Body body) {
            TotalPrice += body.Price;
        }

        public void Visit(Salon salon) {
            TotalPrice += salon.Price;
        }

        public void Visit(Cockpit cockpit) {
            TotalPrice += cockpit.Price;
        }

        public void Visit(Audio audio) {
            TotalPrice += audio.Price;
        }

        public void Visit(Reciever reciever) {
            TotalPrice += reciever.Price;
        }

        public void Visit(Speakers speakers) {
            TotalPrice += speakers.Price;
        }

        public void Visit(Wheel wheel) {
            TotalPrice += wheel.Price;
        }

        public void Visit(Engine engine) {
            TotalPrice += engine.Price;
        }

        public void Visit(ColorType colorType) {
            TotalPrice += colorType.Price;
        }

        public void Visit(Tire tire) {
            TotalPrice += tire.Price;
        }

        public void Visit(Disc disc) {
            TotalPrice += disc.Price;
        }

        public void Visit(Turbo turbo) {
            TotalPrice += turbo.Price;
        }
    }

    public class UpdatePriceVisitor : IVisitor {
        private readonly decimal multiplier;

        public UpdatePriceVisitor(decimal multiplier) {
            this.multiplier = multiplier;
        }

        public void Visit(Car car) {
            car.Price *= multiplier;
        }

        public void Visit(Body body) {
            body.Price *= multiplier;
        }

        public void Visit(Salon salon) {
            salon.Price *= multiplier;
        }

        public void Visit(Cockpit cockpit) {
            cockpit.Price *= multiplier;
        }

        public void Visit(Audio audio) {
            audio.Price *= multiplier;
        }

        public void Visit(Reciever reciever) {
            reciever.Price *= multiplier;
        }

        public void Visit(Speakers speakers) {
            speakers.Price *= multiplier;
        }

        public void Visit(Wheel wheel) {
            wheel.Price *= multiplier;
        }

        public void Visit(Engine engine) {
            engine.Price *= multiplier;
        }

        public void Visit(ColorType colorType) {
            colorType.Price *= multiplier;
        }

        public void Visit(Tire tire) {
            tire.Price *= multiplier;
        }

        public void Visit(Disc disc) {
            disc.Price *= multiplier;
        }

        public void Visit(Turbo turbo) {
            turbo.Price *= multiplier;
        }
    }

    public class CustomSummaryVisitor : IVisitor {
        public decimal TotalPrice { get; private set; }

        public void Visit(Car car) {}

        public void Visit(Body body) {}

        public void Visit(Salon salon) {
            TotalPrice += salon.Price;
        }

        public void Visit(Cockpit cockpit) {}

        public void Visit(Audio audio) {}

        public void Visit(Reciever reciever) {
            TotalPrice += reciever.Price;
        }

        public void Visit(Speakers speakers) {
            TotalPrice += speakers.Price;
        }

        public void Visit(Wheel wheel) {}

        public void Visit(Engine engine) {}

        public void Visit(ColorType colorType) {}

        public void Visit(Tire tire) {
            TotalPrice += tire.Price;
        }

        public void Visit(Disc disc) {
            TotalPrice += disc.Price;
        }

        public void Visit(Turbo turbo) {}
    }
}