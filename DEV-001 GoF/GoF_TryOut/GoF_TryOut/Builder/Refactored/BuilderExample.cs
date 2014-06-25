using System;

namespace GoF_TryOut.Builder.Refactored {
    public class BuilderExampleRefactored {
        public BuilderExampleRefactored() {
            var car = CreateCar();
            var fullPrice = car.GetFullPrice();

            Console.WriteLine(fullPrice);
            Console.WriteLine(CreateCarByBuilder().GetFullPrice());
        }

        private Car CreateCar() {
            var car1 = new Car{Price = 1};
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

        private Car CreateCarByBuilder() {
            return new CarBuilder(1)
            .AddBody(1)
                .WithColor(1)
                .WithSalon(1,1,1)
                .Build()
            .AddEngine(1)
                .WithTurbo(1)
                .Build()
            .AddWheels(4,1)
                .WithDisk(1)
                .WithTire(1)
                .Build()
            .Build();
        }
    }
}