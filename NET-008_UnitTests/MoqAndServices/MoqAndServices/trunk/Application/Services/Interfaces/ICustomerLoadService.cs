using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;

namespace Application.Services.Interfaces {
    public interface ICustomerLoadService {
        event Action<Task> CustomersLoaded;
        Task<List<Customer>> LoadAllCustomersAsync();
    }
}