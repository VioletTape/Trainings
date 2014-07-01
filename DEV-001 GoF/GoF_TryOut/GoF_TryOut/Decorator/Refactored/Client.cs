namespace GoF_TryOut.Decorator.Refactored {
    public class Client {
        public Client() {
            var user = new User();
            var adderss = new Address();

            var deliveryService = new DeliveryService();
            var loggingDecorator = new DeliveryServiceLoggingDecorator(deliveryService);
            var roleDecorator = new DeliveryServiceRoleDecorator(loggingDecorator, user);
            
            new DeliveryServiceDiscountDecorator(roleDecorator, 5)
                .CalculateDelivery(adderss);
        }
    }
}