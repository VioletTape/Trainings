using Domain;
using FluentAssertions;
using Infrastructure;
using Infrastructure.Adapters;
using NUnit.Framework;
using SpecificationMain;


/////////
namespace Tests {
    [TestFixture]
    public class CustomerAdapterTests : TestsBase{
        [Test]
        public void CanReconstitute() {
            // Arrange
            var customerAdapter = new CustomerAdapter();

            // Act
            var customers = customerAdapter.Get(new UnitOfWork(), new NullSpecification<Customer>());

            // Assert
            customers.Count.Should().Be(5);
        }
    }
}