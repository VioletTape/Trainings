using System;

namespace GoF_ShowCase.ChainOfResponsibility.GroupDelegates {
    public class DefaultOrderHandler : IOrderHandler {
        public bool Process(OrderData orderData) {
            if (orderData.Id != 0) {
                return false;
            }

            Console.WriteLine("Default order handler");
            orderData.Id = 5;

            return true;
        }
    }
}