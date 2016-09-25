using System.Data.Linq;
using Domain;
using Infrastructure.Adapters.Base;
using Infrastructure.Context;
using Infrastructure.Translators;

namespace Infrastructure.Adapters {
    public class CustomerAdapter : ReadOnlyAdapter<Customer, customer> {
        public CustomerAdapter() : base(new CustomerTranslator()) {}

        protected override void DoConfigureLoad(DataLoadOptions options) {
            options.LoadWith<customer>(c => c.invoices);
        }
    }
}