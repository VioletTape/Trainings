using System.Linq;

namespace GoF_TryOut.Adapter.Refactored {
    public class CustomerAdapter : Adapter<Customer> {
        public CustomerAdapter(Table<Customer> table) : base(table) {}

        public override IQueryable<Customer> Convert(Specification<Customer> specification) {
            var query = CommonConditions(specification);

            var name = specification.ExtractSupersetSpecification<CustomerNameStartFrom>();
            if (name != null) {
                query = query.Where(c => c.Name.StartsWith(name.NameStartsFrom));
            }

            return query;
        }
    }
}