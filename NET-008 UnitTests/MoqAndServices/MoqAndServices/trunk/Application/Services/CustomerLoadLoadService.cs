using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.Services.Interfaces;
using StructureMap;

namespace Application.Services {
    public class CustomerLoadService : ICustomerLoadService {
        private readonly IDataFacade facade;

        public CustomerLoadService() {
            facade = ObjectFactory.GetInstance<IDataFacade>();
        }

        public event Action<Task> CustomersLoaded;

        public Task<List<Customer>> LoadAllCustomersAsync() {
            var task = new Task<List<Customer>>(LoadAllCustomers);

            if(CustomersLoaded != null)
                task.ContinueWith(CustomersLoaded);

            task.Start();

            return task;
        }

        private List<Customer> LoadAllCustomers() {
            return facade.Get<Customer>(i => true);
        }
    }
}