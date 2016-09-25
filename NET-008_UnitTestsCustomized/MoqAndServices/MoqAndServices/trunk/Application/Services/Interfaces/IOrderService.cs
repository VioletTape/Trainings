using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;

namespace Application.Services.Interfaces {
    public interface IOrderService {
        event Action<Task> OrdersLoaded;
        Task<List<Order>> LoadOrdersByAsync(Customer customer);
    }
}