using Domain;
using Domain.Specifications;
using FluentAssertions;
using Infrastructure;
using NUnit.Framework;
using SpecificationMain;

namespace Tests {
    [TestFixture]
    public class FacadeTests : TestsBase {
        private InfrastructureFacade infrastructureFacade;
           
        [SetUp]
        public void InitTest() {
            infrastructureFacade = new InfrastructureFacade();
        }

        [Test]
        public void CanGetSomeData() {
            // Act
            var customers = infrastructureFacade.Get(Specification<Customer>.Null);

            // Assert
            customers.Count.Should().Be(5);
        }

        [Test]
        public void UnitOfWorkShouldContainData() {
            // Arrange

            // Act
            infrastructureFacade.Get(Specification<Customer>.Null);

            // Assert
            infrastructureFacade.UnitOfWork
                .GetActive<Customer>()
                .Count.Should().Be(5);
        }

        
        [Test]
        public void UnitOfWorkShouldContainDataX() {
            // Arrange

            // Act
            infrastructureFacade.Get(new CustomerTitleStartsWith("A") 
                                     & new ActiveCustomer());

            // Assert
            infrastructureFacade.UnitOfWork
                .GetActive<Customer>()
                .Count.Should().Be(5);
        }
    }
}