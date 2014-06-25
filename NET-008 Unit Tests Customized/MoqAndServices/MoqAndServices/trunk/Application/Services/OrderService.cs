using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.Services.Interfaces;
using StructureMap;

namespace Application.Services {
    public class OrderService : IOrderService {
        private readonly IDataFacade facade;

        public OrderService() {
            facade = ObjectFactory.GetInstance<IDataFacade>();
        }

        public event Action<Task> OrdersLoaded;

        public Task<List<Order>> LoadOrdersByAsync(Customer customer) {
            var task = new Task<List<Order>>(LoadOrders, customer);

            if (OrdersLoaded != null)
                task.ContinueWith(OrdersLoaded);

            task.Start();

            return task;
        }

        private List<Order> LoadOrders(object customer) {
            return facade.Get<Order>(i => true);
        }
    }
}