using System;

namespace Application.Core {
    public class Customer {
        public string Name;
        public string Phone;

        public Guid Id;
        public bool IsAlive;

        public Customer() {
            Id = Guid.NewGuid();
            IsAlive = true;
        }
    }
}