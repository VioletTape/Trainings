using System;
using System.Collections.Generic;

namespace Domain {
    public class Invoice {
        public Guid InvoiceId;
        public Customer Customer;
        public string Address;
        public DateTime Date;

        public bool IsPaid;
        public bool IsShiped;

        public List<Ware> Wares = new List<Ware>();

        public Invoice() {
            InvoiceId = Guid.NewGuid();
        }
    }
}