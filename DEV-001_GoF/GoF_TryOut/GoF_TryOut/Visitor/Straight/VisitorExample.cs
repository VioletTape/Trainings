using System;
using System.Linq;

namespace GoF_TryOut.Visitor.Straight {
    public class VisitorExample {
        public VisitorExample() {
            var car = CreateCar();
            var fullPrice = car.GetFullPrice();

            var body = car.Parts.OfType<Body>().Single();
            var colorTypes = body.Parts.OfType<ColorType>().Single();
            // you can miss or forget something.. 
            body.Price *= 1.2m;
            colorTypes.Price *= 1.2m;

            Console.WriteLine(fullPrice);
        }

        private Car CreateCar() {
            var car = new Car {Price = 1};
            var body = new Body {Price = 1};
            body.Add(new ColorType {Price = 1});
            var salon = new Salon {Price = 1};
            var cockpit = new Cockpit {Price = 1};
            var audio = new Audio {Price = 1};
            audio.Add(new Reciever {Price = 1});
            audio.Add(new Speakers {Price = 1});

            cockpit.Add(audio);
            salon.Add(cockpit);
            body.Add(salon);

            car.Add(body);

            var engine = new Engine {Price = 1};
            engine.Add(new Turbo {Price = 1});
            car.Add(engine);

            var wheel = new Wheel {Price = 1};
            wheel.Add(new Disc {Price = 1});
            wheel.Add(new Tire {Price = 1});
            car.Add(wheel);

            wheel = new Wheel {Price = 1};
            wheel.Add(new Disc {Price = 1});
            wheel.Add(new Tire {Price = 1});
            car.Add(wheel);

            wheel = new Wheel {Price = 1};
            wheel.Add(new Disc {Price = 1});
            wheel.Add(new Tire {Price = 1});
            car.Add(wheel);

            wheel = new Wheel {Price = 1};
            wheel.Add(new Disc {Price = 1});
            wheel.Add(new Tire {Price = 1});
            car.Add(wheel);


            return car;
        }
    }
}