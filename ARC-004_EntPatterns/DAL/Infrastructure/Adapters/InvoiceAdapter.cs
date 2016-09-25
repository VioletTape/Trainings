using System;
using Domain;
using Infrastructure.Adapters.Base;
using Infrastructure.Context;
using Infrastructure.Translators;

namespace Infrastructure.Adapters {
    public class InvoiceAdapter : WriteAdapter<Invoice, invoice> {
        public InvoiceAdapter() : base(new InvoiceTranslator()) {
        }

protected override Func<invoice, bool> GetIdPredicate(Invoice domainObject) {
    return t => t.InvoiceId == domainObject.InvoiceId;
}
    }
}