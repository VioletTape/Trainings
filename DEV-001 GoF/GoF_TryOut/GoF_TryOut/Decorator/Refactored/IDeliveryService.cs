namespace GoF_TryOut.Decorator.Refactored {
    public interface IDeliveryService {
        void CalculateDelivery(Address adderss);
    }

    public class DeliveryService : IDeliveryService {
        public void CalculateDelivery(Address adderss) {
            var price = 3m;
            if (adderss.Country == "Usa") {
                if (adderss.State == "Utah") {
                    price += 1.2m;
                }
                else {
                    price += 4.6m;
                }
            }
            else {
                price += 10;
            }

            adderss.DeliveryPrice = price;
        }
    }
}