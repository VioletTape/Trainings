using System;

namespace GoF_TryOut.Adapter.StraightCode {
    public class Customer {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Order {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
    }
}