using Domain;
using Infrastructure.Context;
using SpecificationMain;

namespace Infrastructure.Translators {
    public class InvoiceTranslator : Translator<Invoice, invoice> {
        protected override Invoice DoReconstitute(invoice dataObject, IsLazy<Invoice> isLazy, IUnitOfWork unitOfWork) {
            return new Invoice {
                                   InvoiceId = dataObject.InvoiceId
                               };
        }

        protected override bool GetPredicate(Invoice domain, invoice data) {
            return data.InvoiceId == domain.InvoiceId;
        }

public override void Persist(Invoice domainObject, invoice dataObject, UnitOfWork unitOfWork) {
    dataObject.InvoiceId = domainObject.InvoiceId;
    dataObject.CustomerId = domainObject.Customer.CustomerId;
    dataObject.Address = domainObject.Address;

    dataObject.invoceContents.Clear();
    foreach (var ware in domainObject.Wares) {
         var invoceContent = new invoceContent {
                                                   InvoiceId = domainObject.InvoiceId,
                                                   WareId = ware.WareId,
                                                   Date = domainObject.Date,
                                                   Price = ware.Price,
                                                   Quantity = ware.Quantity,
                                               };
  
        dataObject.invoceContents.Add(invoceContent);
    }
}

public override void AssertCanBeDeleted(invoice dataObject) {}
    }
}