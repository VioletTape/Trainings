using System;
using System.Collections.Generic;

namespace GoF_TryOut.Visitor.Refactored {
    public class CompositeExample {
        public CompositeExample() {
            var car = CreateCar();
            var fullPrice = car.GetFullPrice();

            Console.WriteLine(fullPrice);
        }

        private Composite.Straight.Car CreateCar() {

            var car = new Composite.Straight.Car{ 
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
            Engine = new Composite.Straight.Engine() {
                Price = 1,
                Turbo = {Price = 1}
            },
                Price = 1,
                Wheels = new List<Composite.Straight.Wheel> {
                    new Composite.Straight.Wheel {
                        Disc = {Price = 1},
                        Price = 1,
                        Tire = {Price = 1}
                    },
                    new Composite.Straight.Wheel {
                        Disc = {Price = 1},
                        Price = 1,
                        Tire = {Price = 1}
                    },
                    new Composite.Straight.Wheel {
                        Disc = {Price = 1},
                        Price = 1,
                        Tire = {Price = 1}
                    },
                    new Composite.Straight.Wheel {
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