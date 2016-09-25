namespace GoF_ShowCase.ChainOfResponsibility.NearRealLife {
    public static class Example{
        private static OrderManager CreateOrderManager() {
            var manager = new OrderManager(new DefaultOrderHandler());
            manager.AddHandler(new FavCustomerOrderHandler());
            manager.AddHandler(new LargeOrderHandler());

            return manager;
        }

        public static void Execute() {
            var orderManager = CreateOrderManager();

            var orderData = new OrderData {
                Id = 0,
                Amount = 100,
                CustomerId = 15,
                ItemId = 8
            };

            orderManager.ProcessNewOrder(orderData);
        }
    }
}