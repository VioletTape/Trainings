namespace GoF_ShowCase.ChainOfResponsibility.GroupDelegates {
   
    /*
     
      Обратите внимание, что в этом случае так же важен порядок 
      добавления, при этом последним идет обработчик по умолчанию. 
      Однако никакого контроля в этом случае нет и заказ может 
      оказаться не обработанным.
     
     */
    
    public static class Example {


         delegate bool OrderHandlerDelegate(OrderData orderData);
        
        private static OrderHandlerDelegate CreateOrderManager() {
            var favCustomerOrderHandler = new FavCustomerOrderHandler();
            var largeOrderHandler = new LargeOrderHandler();
            var defaultOrderHandler = new DefaultOrderHandler();

            var manager = new OrderHandlerDelegate(favCustomerOrderHandler.Process);
            manager += new OrderHandlerDelegate(largeOrderHandler.Process);
            manager += new OrderHandlerDelegate(defaultOrderHandler.Process);

            return manager;
        }

        public static void Execute() {
            var orderManager = CreateOrderManager();

            var orderData = new OrderData {
                Id = 0,
                Amount = 10,
                CustomerId = 5,
                ItemId = 8
            };

            orderManager(orderData);
        }
    }
}