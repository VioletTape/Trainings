using System;
using Domain;
using Infrastructure;
using Infrastructure.Adapters;
using NUnit.Framework;
using SpecificationMain;

namespace Tests {
    [TestFixture]
    public class InvoiceAdapterTests : TestsBase {
        [Test]
        public void CanSaveInvoice() {
            // Arrange
            var unitOfWork = new UnitOfWork();
            var customers = new CustomerAdapter().Get(unitOfWork, new NullSpecification<Customer>());
            var wares = new WareAdapter().Get(unitOfWork, new NullSpecification<Ware>());

            var invoice = new Invoice();
            invoice.Customer = customers[0];
            invoice.Wares.Add(wares[0].WithQuantity(200));
            invoice.Date = DateTime.Now;

            unitOfWork.Save(invoice);
            // Act

            new InvoiceAdapter().Save(unitOfWork);
            // Assert

        }
    }
}