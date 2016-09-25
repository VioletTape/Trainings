namespace GoF_TryOut.Decorator.Straight {
    public class Client {
        public Client() {
            var log = new Log();
            var user = new User();
            var adderss = new Address();

            new DeliveryService(log, user).CalculateDelivery(adderss, true, 5, true);
        }
    }
}