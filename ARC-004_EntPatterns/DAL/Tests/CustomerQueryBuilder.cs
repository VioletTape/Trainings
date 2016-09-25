using Domain.Specifications;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.QueryBuilders;
using NUnit.Framework;

namespace Tests {
    [TestFixture]
    public class CustomerQueryBuilderTests : TestsBase {
        [Test]
        public void CanOptimizeActiveCustomer() {
            // Arrange
            var customers = new WarehouseDataContext().GetTable<customer>();

            // Act
            var queryable = new CustomerQueryBuilder().Optimize(customers, new ActiveCustomer()).ToString();

            // Assert
        }

        [Test]
        public void GetActiveCustomer() {
            // Arrange

            // Act
            var customers = new InfrastructureFacade().Get(new ActiveCustomer());

            // Assert
        }
    }
}