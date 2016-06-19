using System;
using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.ChainsOfResponsobility.Refactored2 {
    public class Client {
        public Client() {
            var address = new Address("Poland, Wrocław, Gołężycka, 42");
            var calc = new CalcDeliveryService().Calc(address);
        }
    }


    public class CalcDeliveryService {
        public List<DeliverOptions> Calc(Address address) {
            return new LocalDelivererNode(
                new EUDelivererNode(
                    new WorldDelivererNode(null))).CheckPrices(address);
        }
    }

    public class LocalDelivererNode : HandleDeliverer {
        private readonly List<LocalDeliverer> localDeliverers;

        public LocalDelivererNode(HandleDeliverer handler) : base(handler) {
            localDeliverers = new List<LocalDeliverer> {
                                                           new LocalDeliverer("Argo"),
                                                           new LocalDeliverer("Ters")
                                                       };
        }

        public override List<DeliverOptions> CheckPrices(Address address) {
            var prices = localDeliverers.Select(d => d.CheckPrices(address));
            var minPrice = prices.Min(d => d.Price);
            return prices.Where(d => d.Price == minPrice).Select(d => d).ToList();
        }
    }


    public class EUDelivererNode : HandleDeliverer {
        private readonly HandleDeliverer handler;
        private readonly List<EuroDeliverer> localDeliverers;

        public EUDelivererNode(HandleDeliverer handler) : base(handler) {
            this.handler = handler;
            localDeliverers = new List<EuroDeliverer> {
                                                          new EuroDeliverer("EuroExpress"),
                                                          new EuroDeliverer("PigeonMail"),
                                                          new EuroDeliverer("WheelsOfPost")
                                                      };
        }

        public override List<DeliverOptions> CheckPrices(Address address) {
            var prices = localDeliverers.Select(d => d.CheckPrices(address));
            var minPrice = prices.Min(d => d.Price);
            return prices.Where(d => d.Price == minPrice).Select(d => d).ToList();
        }
    }

    public class WorldDelivererNode : HandleDeliverer {
        public WorldDelivererNode(HandleDeliverer handler) : base(handler) {
            var list = new List<WorldDeliverer> {
                                                    new WorldDeliverer("DHL"),
                                                    new WorldDeliverer("PonyExpress"),
                                                    new WorldDeliverer("FedEx"),
                                                    new WorldDeliverer("EmPost")
                                                };
        }

        public override List<DeliverOptions> CheckPrices(Address address) {
            return new List<DeliverOptions>();
        }
    }

    public abstract class HandleDeliverer {
        private readonly HandleDeliverer handler;

        protected HandleDeliverer(HandleDeliverer handler) {
            this.handler = handler;
        }

        public List<DeliverOptions> CheckPricesX(Address address) {
            var deliverOptionses = CheckPrices(address);
            return deliverOptionses.Any()
                       ? deliverOptionses
                       : NextHandler().CheckPrices(address);
        }

        public abstract List<DeliverOptions> CheckPrices(Address address);

        public virtual HandleDeliverer NextHandler() {
            return handler;
        }
    }


    public class WorldDeliverer {
        public WorldDeliverer(string empost) {}

        public DeliverOptions CheckPrices(Address address) {
            return new DeliverOptions();
        }
    }

    public class EuroDeliverer {
        public EuroDeliverer(string euroexpress) {}

        public DeliverOptions CheckPrices(Address address) {
            return new DeliverOptions();
        }
    }

    public class LocalDeliverer {
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