using System;
using System.Collections.Generic;

namespace GoF_TryOut.Composite.Straight {
    public class CompositeExample {
        public CompositeExample() {
            var car = CreateCar();
            var fullPrice = car.GetFullPrice();

            Console.WriteLine(fullPrice);
        }

        private Car CreateCar() {
            var car = new Car {
                                  Body = {
                                             ColorType = {Price = 1},
                                             Price = 1,
                                             Salon = {
                                                         Cockpit = {
                                                                       Audio = {
                                                                                   Price = 1,
                                                                                   Reciever = {Price = 1},
                                                                                   Speakers = {Price = 1}
                                                                               },
                                                                       Price = 1
                                                                   },
                                                         Price = 1
                                                     }
                                         },
                                  Engine = new Engine() {
                                                            Price = 1,
                                                            Turbo = {Price = 1}
                                                        },
                                  Price = 1,
                                  Wheels = new List<Wheel> {
                                                               new Wheel {
                                                                             Disc = {Price = 1},
                                                                             Price = 1,
                                                                             Tire = {Price = 1}
                                                                         },
                                                               new Wheel {
                                                                             Disc = {Price = 1},
                                                                             Price = 1,
                                                                             Tire = {Price = 1}
                                                                         },
                                                               new Wheel {
                                                                             Disc = {Price = 1},
                                                                             Price = 1,
                                                                             Tire = {Price = 1}
                                                                         },
                                                               new Wheel {
                                                                             Disc = {Price = 1},
                                                                             Price = 1,
                                                                             Tire = {Price = 1}
                                                                         },
                                                           }
                              };

            return car;
        }
    }
}