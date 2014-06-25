namespace GoF_TryOut.Builder.Refactored {
    public class CarBuilder {
        private readonly Car car;

        public CarBuilder(decimal price) {
            car = new Car{Price =  price};
        }

        public BodyBuilder AddBody(decimal price) {
            var bodyBuilder = new BodyBuilder(this, car, price);
            return bodyBuilder;
        }

        public EngineBuilder AddEngine(decimal price) {
            var engineBuilder = new EngineBuilder(this, car, price);
            return engineBuilder;
        }

        public WheelBuilder AddWheels(int wheelCount, decimal price) {
            var wheelBuilder = new WheelBuilder(this, car, wheelCount, price);
            return wheelBuilder;
        }

        public Car Build() {
            return car;
        }

        public class WheelBuilder {
            private readonly CarBuilder carBuilder;
            private readonly Car car;
            private readonly int wheelCount;
            private readonly decimal price;
            private decimal tirePrice;
            private decimal diskPrice;

            public WheelBuilder(CarBuilder carBuilder, Car car, int wheelCount, decimal price) {
                this.carBuilder = carBuilder;
                this.car = car;
                this.wheelCount = wheelCount;
                this.price = price;
            }

            public WheelBuilder WithTire(decimal price) {
                tirePrice = price;
                return this;
            }

            public WheelBuilder WithDisk(decimal price) {
                diskPrice = price;
                return this;
            }

            public CarBuilder Build() {
                for (int i = 0; i < wheelCount; i++) {
                    var wheel = new Wheel{Price = price};
                    wheel.Add(new Disc{Price = diskPrice});
                    wheel.Add(new Tire{Price = tirePrice});
                    car.Add(wheel);
                }

                return carBuilder;
            }
        }

        public class BodyBuilder {
            private readonly CarBuilder carBuilder;
            private readonly Car car;
            private readonly Body body;

            public BodyBuilder(CarBuilder carBuilder, Car car, decimal price) {
                this.carBuilder = carBuilder;
                this.car = car;
                body = new Body {Price = price};
            }

            public BodyBuilder WithColor(decimal price) {
                var colorType = new ColorType {Price = price};
                body.Add(colorType);
                return this;
            }

            public BodyBuilder WithSalon(decimal price, decimal cockpitPrice, decimal audioPrice) {
                var salon = new Salon {Price = price};
                var cockpit = new Cockpit {Price = cockpitPrice};
                var audio = new Audio {Price = audioPrice};
                audio.Add(new Speakers {Price = 1});
                audio.Add(new Reciever {Price = 1});

                cockpit.Add(audio);
                salon.Add(cockpit);

                body.Add(salon);
                return this;
            }

            public CarBuilder Build() {
                car.Add(body);
                return carBuilder;
            }
        }

        public class EngineBuilder {
            private readonly CarBuilder carBuilder;
            private readonly Car car;
            private Engine engine;

            public EngineBuilder(CarBuilder carBuilder, Car car, decimal price) {
                this.carBuilder = carBuilder;
                this.car = car;

                engine = new Engine{Price = price};
            }

            public EngineBuilder WithTurbo(decimal price) {
                engine.Add(new Turbo{Price = 1});
                return this;
            }

            public CarBuilder Build() {
                car.Add(engine);
                return carBuilder;
            }
        }
    }
}