using System;

namespace GoF_ShowCase.ChainOfResponsibility.GroupDelegates {
    public class LargeOrderHandler : IOrderHandler {
        public bool Process(OrderData orderData) {
            if ((orderData.Id != 0) || (orderData.Amount < 20)) {
                return false;
            }

            Console.WriteLine("Large order handler.");
            orderData.Id = 42;

            return true;
        }
    }

    public class FavCustomerOrderHandler : IOrderHandler {
        public bool Process(OrderData orderData) {
            if ((orderData.Id != 0) || (orderData.CustomerId > 10)) {
                return false;
            }

            Console.WriteLine("Favorite customer order handler.");
            orderData.Id = 77;

            return true;
        }
    }
}