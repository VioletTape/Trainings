namespace GoF_TryOut.Decorator.Refactored {
    public class DeliveryServiceLoggingDecorator : IDeliveryService
    {
        private readonly IDeliveryService deliveryService;
        private Log log;

        public DeliveryServiceLoggingDecorator(IDeliveryService deliveryService)
        {
            this.deliveryService = deliveryService;
            log = new Log();
        }

        public void CalculateDelivery(Address adderss)
        {
            log.Write("Enter CalculateDelivery method");
            log.Write("   Args address " + adderss);

            deliveryService.CalculateDelivery(adderss);

            log.Write("Exit CalculateDelivery method");
        }
    }

    public class DeliveryServiceDiscountDecorator : IDeliveryService
    {
        private readonly IDeliveryService deliveryService;
        private readonly decimal discount;

        public DeliveryServiceDiscountDecorator(IDeliveryService deliveryService, decimal discount)
        {
            this.deliveryService = deliveryService;
            this.discount = discount;
        }

        public void CalculateDelivery(Address adderss)
        {
            deliveryService.CalculateDelivery(adderss);
            adderss.DeliveryPrice *= (100 - discount) / 100;
        }
    }

    public class DeliveryServiceRoleDecorator : IDeliveryService
    {
        private readonly IDeliveryService deliveryService;
        private readonly User user;

        public DeliveryServiceRoleDecorator(IDeliveryService deliveryService, User user)
        {
            this.deliveryService = deliveryService;
            this.user = user;
        }

        public void CalculateDelivery(Address adderss)
        {
            deliveryService.CalculateDelivery(adderss);

            switch (user.Role)
            {
                case Role.Preffered:
                    adderss.DeliveryPrice *= 0.95m;
                    break;
                case Role.Vip:
                    adderss.DeliveryPrice *= 0.9m;
                    break;
                case Role.Exclusive:
                    adderss.DeliveryPrice *= 0.8m;
                    break;
            }
        }
    }
}