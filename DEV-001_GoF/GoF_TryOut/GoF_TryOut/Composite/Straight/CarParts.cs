using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Composite.Straight {
    public class Car {
        public Body Body { get; set; }
        public List<Wheel> Wheels { get; set; }
        public Engine Engine { get; set; }

        public decimal Price { get; set; }

        public Car() {
            Wheels = new List<Wheel>();
            Engine = new Engine();
            Body = new Body();
        }

        public decimal GetFullPrice() {
            return Price + Engine.GetFullPrice() + Wheels.Sum(i => i.GetFullPrice());
        }
    }

    public class Body {
        public ColorType ColorType { get; set; }

        public Salon Salon { get; set; }

        public decimal Price { get; set; }

        public Body() {
            ColorType = new ColorType();
            Salon = new Salon();
        }

        public decimal GetFullPrice() {
            return Price + Salon.GetFullPrice() + ColorType.Price;
        }
    }

    public class Salon {
        public Cockpit Cockpit { get; set; }

        public decimal Price { get; set; }

        public Salon() {
            Cockpit = new Cockpit();
        }

        public decimal GetFullPrice() {
            return Price + Cockpit.GetFullPrice();
        }
    }

    public class Cockpit {
        public Audio Audio { get; set; }

        public decimal Price { get; set; }

        public Cockpit() {
            Audio = new Audio();
        }

        public decimal GetFullPrice() {
            return Price + Audio.GetFullPrice();
        }
    }

    public class Audio {
        public Speakers Speakers { get; set; }
        public Reciever Reciever { get; set; }

        public decimal Price { get; set; }

        public Audio() {
            Speakers = new Speakers();
            Reciever = new Reciever();
        }

        public decimal GetFullPrice() {
            return Price + Speakers.Price + Reciever.Price;
        }
    }

    public class Reciever {
        public decimal Price { get; set; }
    }

    public class Speakers {
        public decimal Price { get; set; }
    }

    public class Wheel {
        public Tire Tire { get; set; }

        public Disc Disc { get; set; }
        public decimal Price { get; set; }

        public Wheel() {
            Tire = new Tire();
            Disc = new Disc();
        }

        public decimal GetFullPrice() {
            return Price + Tire.Price + Disc.Price;
        }
    }

    public class Engine {
        public Turbo Turbo { get; set; }
        public decimal Price { get; set; }

        public Engine() {
            Turbo = new Turbo();
        }

        public decimal GetFullPrice() {
            return Price + Turbo.Price;
        }
    }

    public class ColorType {
        public decimal Price { get; set; }
    }

    public class Tire {
        public decimal Price { get; set; }
    }

    public class Disc {
        public decimal Price { get; set; }
    }

    public class Turbo {
        public decimal Price { get; set; }
    }
}