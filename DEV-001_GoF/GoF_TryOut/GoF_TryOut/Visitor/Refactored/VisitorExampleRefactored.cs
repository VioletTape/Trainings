using System;

namespace GoF_TryOut.Visitor.Refactored {
    public class VisitorExampleRefactored {
        public VisitorExampleRefactored() {
            var car = CreateCar();
            var fullPrice = car.GetFullPrice();

            var sumVisitor = new SummarizeCostVisitor();
            car.Accept(sumVisitor);

            var updatePriceVisitor = new UpdatePriceVisitor(1.5m);
            car.Accept(updatePriceVisitor);

            var customSummaryVisitor = new CustomSummaryVisitor();
            car.Accept(customSummaryVisitor);

            Console.WriteLine(fullPrice);
            Console.WriteLine(sumVisitor.TotalPrice);
            Console.WriteLine(customSummaryVisitor.TotalPrice);
        }

        private Car CreateCar() {
            var car1 = new Car {Price = 1};
            var body = new Body {Price = 1};
            body.Add(new ColorType {Price = 1});
            var salon = new Salon {Price = 1};
            var cockpit = new Cockpit {Price = 1};
            var carPart = new Audio {Price = 1};
            carPart.Add(new Reciever {Price = 1});
            carPart.Add(new Speakers {Price = 1});

            cockpit.Add(carPart);
            salon.Add(cockpit);
            body.Add(salon);
            car1.Add(body);

            var engine = new Engine {Price = 1};
            engine.Add(new Turbo {Price = 1});
            car1.Add(engine);

            var wheel = new Wheel {Price = 1};
            wheel.Add(new Disc {Price = 1});
            wheel.Add(new Tire {Price = 1});
            car1.Add(wheel);

            wheel = new Wheel {Price = 1};
            wheel.Add(new Disc {Price = 1});
            wheel.Add(new Tire {Price = 1});
            car1.Add(wheel);

            wheel = new Wheel {Price = 1};
            wheel.Add(new Disc {Price = 1});
            wheel.Add(new Tire {Price = 1});
            car1.Add(wheel);

            wheel = new Wheel {Price = 1};
            wheel.Add(new Disc {Price = 1});
            wheel.Add(new Tire {Price = 1});
            car1.Add(wheel);


            return car1;
        }
    }
}