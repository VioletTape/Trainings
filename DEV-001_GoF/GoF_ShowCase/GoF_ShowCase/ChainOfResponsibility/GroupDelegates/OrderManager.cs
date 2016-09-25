using System;
using System.Collections.Generic;

namespace GoF_ShowCase.ChainOfResponsibility.GroupDelegates {
    /*
     В данной реализации можно отметить следующие моменты:

список обработчиков хранится в поле _handlers;
порядок добавления обработчиков определяет последовательность их вызовов;
конструктор обязывает указать обработчик по умолчанию _defaultHandler;
обработчик по умолчанию всегда вызывается последним и обязан обработать запрос, в противном случае возникнет исключительная ситуация.
     
     */


    public class OrderManager {
        private readonly List<IOrderHandler> handlers = new List<IOrderHandler>();
        private readonly IOrderHandler defaultHandler;

        public OrderManager(IOrderHandler defaultHandler) {
            if (defaultHandler == null) {
                throw new NullReferenceException();
            }

            this.defaultHandler = defaultHandler;
        }

        public void AddHandler(IOrderHandler handler) {
            handlers.Add(handler);
        }

        public void ProcessNewOrder(OrderData orderData) {
            foreach (var handler in handlers) {
                if (handler.Process(orderData)) {
                    return;
                }
            }

            if (!defaultHandler.Process(orderData)) {
                throw new InvalidOperationException();
            }
        }
    }
}