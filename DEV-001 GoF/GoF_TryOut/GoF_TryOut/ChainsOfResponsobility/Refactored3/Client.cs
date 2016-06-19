using System;
using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.ChainsOfResponsobility.Refactored3 {
    public class Client {
        public Client() {
            var address = new Address("Poland, Wrocław, Gołężycka, 42");
            var calc = new CalcDeliveryService().Calc(address);
        }
    }

    public class CalcDeliveryService {
        public List<DeliverOptions> Calc(Address address) {
            var local = new HandleDeliverer(new LocalDeliverer("Argo"),
                                            new LocalDeliverer("Ters"));

            var euro = new HandleDeliverer(new EuroDeliverer("EuroExpress"),
                                           new EuroDeliverer("PigeonMail"),
                                           new EuroDeliverer("WheelsOfPost"));

            var world = new HandleDeliverer(new WorldDeliverer("DHL"),
                                            new WorldDeliverer("PonyExpress"),
                                            new WorldDeliverer("FedEx"),
                                            new WorldDeliverer("EmPost")
                );
            return local.Next(euro.Next(world)).CheckPricesX(address);
        }
    }

    public class HandleDeliverer {
        private HandleDeliverer handler;
        private readonly IDeliverer[] deliverer;

        public HandleDeliverer(params IDeliverer[] deliverer) {
            this.deliverer = deliverer;
        }

        public List<DeliverOptions> CheckPricesX(Address address) {
            var deliverOptionses = CheckPrices(address);
            return deliverOptionses.Any()
                       ? deliverOptionses
                       : handler.CheckPrices(address);
        }

        internal virtual List<DeliverOptions> CheckPrices(Address address) {
            var prices = deliverer.Select(d => d.CheckPrices(address));
            var minPrice = prices.Min(d => d.Price);
            return prices.Where(d => d.Price == minPrice).Select(d => d).ToList();
        }

        public virtual HandleDeliverer Next(HandleDeliverer handler) {
            this.handler = handler;
            return this;
        }
    }


    public interface IDeliverer {
        DeliverOptions CheckPrices(Address address);
    }


    public class WorldDeliverer : IDeliverer {
        public WorldDeliverer(string empost) {}

        public DeliverOptions CheckPrices(Address address) {
            return new DeliverOptions();
        }
    }

    public class EuroDeliverer : IDeliverer {
        public EuroDeliverer(string euroexpress) {}

        public DeliverOptions CheckPrices(Address address) {
            return new DeliverOptions();
        }
    }

    public class LocalDeliverer : IDeliverer {
        public LocalDeliverer(string argo) {}

        public DeliverOptions CheckPrices(Address address) {
            return new DeliverOptions();
        }
    }


    public class DeliverOptions {
        public Money Price { get; set; }
    }

    public class Money : IComparable {
        public int CompareTo(object obj) {
            return 0;
        }

        public static bool operator >(Money m1, Money m2) {
            return true;
        }

        public static bool operator <(Money m1, Money m2) {
            return true;
        }
    }

    public class Address {
        public Address(string address) {}

        public string Country { get; set; }
    }
}