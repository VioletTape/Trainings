namespace GoF_TryOut.Decorator.Straight {
    public class DeliveryService {
        private readonly Log log;
        private readonly User user;

        public DeliveryService(Log log, User user) {
            this.log = log;
            this.user = user;
        }

        public void CalculateDelivery(Address adderss, bool isDiscounted, decimal discount, bool isLogging) {
            if (isLogging) {
                log.Write("Enter CalculateDelivery method");
                log.Write("   Args address " + adderss);
            }

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

            switch (user.Role) {
                case Role.Preffered:
                    price *= 0.95m;
                    break;
                case Role.Vip:
                    price *= 0.9m;
                    break;
                case Role.Exclusive:
                    price *= 0.8m;
                    break;
            }

            if (isDiscounted) {
                price *= (100 - discount)/100;
            }

            adderss.DeliveryPrice = price;


            if (isLogging) {
                log.Write("Exit CalculateDelivery method");
            }
        }
    }
}