using System;
using System.Collections.Generic;

namespace Domain {
    public class Customer {
        public Guid CustomerId;
        public string Title;
        public string Phone;
        public string Website;

        public List<Invoice> Invoices = new List<Invoice>();
    }
}