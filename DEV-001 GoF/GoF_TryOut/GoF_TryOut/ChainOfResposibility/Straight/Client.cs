using System;

namespace GoF_TryOut.ChainOfResposibility.Straight {
    public class Client {
        public Client() {
            var address = new Address();

            var deliveryPrice = CalculateDeliveryPrice(address);
            if (deliveryPrice > 0) {
                Console.WriteLine("Delivery price is " + deliveryPrice);
            }
            else {
                Console.WriteLine("Can not deliver you postage");
            }
        }

        private static decimal CalculateDeliveryPrice(Address address) {
            var deliveryPrice = -1m;
            if (address.Country == "USA") {
                if (address.State == "Utah") {
                    deliveryPrice = new LocalDeliveryService().CalcDelivery(address);
                }
                else {

                    deliveryPrice = new CountryManDelivery().CalcDelivery(address);
                    if (deliveryPrice <= 0) {
                        deliveryPrice = new AllUsaDelivery().CalcDelivery(address);
                    }
                    if (deliveryPrice <= 0) {
                        deliveryPrice = new LittlePonyExpress().CalcDelivery(address);
                    }
                }
            }
            else {
                deliveryPrice = new LittlePonyExpress().CalcDelivery(address);
                if (deliveryPrice <= 0)
                {
                    deliveryPrice = new WorldExpress().CalcDelivery(address);
                }
            }

            return deliveryPrice;
        }
    }

    internal class WorldExpress : IDeliveryService {
        public decimal CalcDelivery(Address address) {
            return 0;
        }
    }

    internal class LittlePonyExpress : IDeliveryService {
        public decimal CalcDelivery(Address address) {
            return 0;
        }
    }

    internal class AllUsaDelivery : IDeliveryService {
        public decimal CalcDelivery(Address address) {
            return 0;
        }
    }

    internal class CountryManDelivery : IDeliveryService {
        public decimal CalcDelivery(Address address) {
            return 0;
        }
    }

    public interface IDeliveryService {
        decimal CalcDelivery(Address address);
    }

    public class LocalDeliveryService : IDeliveryService {
        public decimal CalcDelivery(Address address) {
            return 0;
        }
    }
}