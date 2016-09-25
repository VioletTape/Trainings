using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Application.Core {
    public class Order {
        private readonly List<OrderItem> items = new List<OrderItem>();

        public Guid Id { get; private set; }

        public string RefNumber { get; private set; }
        public Customer Customer { get; private set; }
        public DateTime CreateTime { get; private set; }


        public ReadOnlyCollection<OrderItem> Items {
            get { return items.AsReadOnly(); }
        }


        public Order(string refNumber, Customer customer) {
            Id = Guid.NewGuid();
            RefNumber = refNumber;
            Customer = customer;
            CreateTime = DateTime.UtcNow;
        }

        public void AddItem(Item item, int quantity) {
            var orderItem = new OrderItem {
                                              ItemId = item.Id,
                                              Quantity = quantity
                                          };

            items.Add(orderItem);
        }
    }
}