using Domain;
using Infrastructure.Context;
using SpecificationMain;

namespace Infrastructure.Translators {
    public class CustomerTranslator : Translator<Customer, customer> {
        private readonly InvoiceTranslator invoiceTranslator;

        public CustomerTranslator() {
            invoiceTranslator = new InvoiceTranslator();
        }

        protected override Customer DoReconstitute(customer dataObject, IsLazy<Customer> isLazy, IUnitOfWork unitOfWork) {
            var entitySet = dataObject.invoices;
            var doReconstitute = new Customer {
                                                  CustomerId = dataObject.CustomerId
                                              };

            if (isLazy.NotContains<Invoice>()) {
                foreach (var invoice in entitySet) {
                    var reconstitute = invoiceTranslator.Reconstitute(invoice
                                                                      , unitOfWork
                                                                      , isLazy.For<Invoice>());
                    doReconstitute.Invoices.Add(reconstitute);
                }
            }
            return doReconstitute;
        }

        protected override bool GetPredicate(Customer domain, customer data) {
            return data.CustomerId == domain.CustomerId;
        }

        public override void Persist(Customer domainObject, customer dataObject, UnitOfWork unitOfWork) {}

        public override void AssertCanBeDeleted(customer dataObject) {}
    }
}