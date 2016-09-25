using System.Linq;
using SpecificationMain;

namespace Domain.Specifications {
    public class ActiveCustomer : Specification<Customer> {
        public override bool IsSatisfiedBy(Customer obj) {
            return obj.Invoices.Any();
        }
    }
}