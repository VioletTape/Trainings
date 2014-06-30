namespace GoF_TryOut.ChainOfResposibility.Straight {
    public interface IDeliveryService {
        decimal CalcDelivery(Address address);
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

    public class LocalDeliveryService : IDeliveryService {
        public decimal CalcDelivery(Address address) {
            return 0;
        }
    }
}