using System;
using System.Collections.Generic;
using System.Linq;
using Application.Core;
using Application.Services.Interfaces;
using FizzWare.NBuilder;

namespace Application.Services {
    public class DataFacade : IDataFacade {
        private readonly Dictionary<Type, dynamic> database = new Dictionary<Type, dynamic>();

        public DataFacade() {
            var customers = new List<Customer> {
                                                   new Customer{Name = "ACME"},
                                                   new Customer{Name = "Balto", IsAlive = false},
                                                   new Customer{Name = "Conso"},
                                                   new Customer{Name = "Zorga"}
                                               };


            database[typeof(Customer)] = customers;

            var items = Builder<Item>.CreateListOfSize(20).Build();

            var orders = new List<Order> {
                                           new Order("001", customers[0]),
                                           new Order("x05", customers[2]),
                                           new Order("3x4", customers[3]),
                                        };

            items.Take(5).ToList().ForEach(i => orders[0].AddItem(i, 2));
            items.Skip(5).Take(2).ToList().ForEach(i => orders[0].AddItem(i, 2));
            items.Skip(7).Take(3).ToList().ForEach(i => orders[0].AddItem(i, 2));

            database[typeof (Item)] = items.ToList();
            database[typeof (Order)] = orders;
            database[typeof (OrderItem)] = orders.SelectMany(i => i.Items).ToList();
        }

        public List<T> Get<T>(Func<T, bool> spec) {
            return ((List<T>) database[typeof (T)]).Where(spec).ToList();
        }
        
    }
}