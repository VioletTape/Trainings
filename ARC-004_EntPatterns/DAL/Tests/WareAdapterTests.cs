using Domain;
using FluentAssertions;
using Infrastructure;
using Infrastructure.Adapters;
using NUnit.Framework;
using SpecificationMain;

namespace Tests {
    [TestFixture]
    public class WareAdapterTests : TestsBase {
        [Test]
        public void CanReconstitute() {
            // Arrange
            var wareAdapter = new WareAdapter();

            // Act
            var customers = wareAdapter.Get(new UnitOfWork(), new NullSpecification<Ware>());

            // Assert
            customers.Count.Should().Be(5);
        }
    }
}