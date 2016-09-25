using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Core;
using Application.Services.Interfaces;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.ModelTest {
    [TestFixture]
    public class WhenSelectCustomers : ModelTestBase {
        private StringBuilder actual;

        [SetUp]
        public void TestInit() {
            actual = new StringBuilder();
            Model.Print = i => actual.AppendLine(i);
        }

        [Test]
        public void ShouldShowCustomerList() {
            // Arrange
            var expected = new StringBuilder();
            expected.AppendLine("Customers Selected and loading...");
            expected.AppendLine("0. Name1");
            expected.AppendLine("1. Name2");
            expected.AppendLine("Select Customer");


            Model.InitModel();

            actual.Clear();
            // Act
            Model.ProcessMainMenu("1");

            // Нельзя так как будет используется настоящий класс, а для модификации нужен вирутальный event, 
            // который видимо создается при использовании интерфейса
            // а создавать виртуальные эвент странно
//             CustomerService.Raise(x => x.CustomersLoaded += null, loadAllCustomersResults);
            CustomerService.As<ICustomerLoadService>().Raise(x => x.CustomersLoaded += null, loadAllCustomersResults);


            // Assert
            actual.ToString()
                .Should()
                .Be(expected.ToString());
        }

        [Test]
        public void ShouldAllowSelectCustomer() {
            // Arrange
            Model.InitModel();
            Model.ProcessMainMenu("1");
            CustomerService.As<ICustomerLoadService>().Raise(x => x.CustomersLoaded += null, loadAllCustomersResults);

            // Act
            Model.OnAnswer("1");

            // Assert
            Model.SelectedCustomer.Name
                .Should()
                .Be("Name2");

            Model.SelectedCustomer.IsAlive
                .Should()
                .BeTrue();

            Model.SelectedCustomer.Phone
                .Should()
                .StartWith("+7");
        }

        public override List<Customer> CustomerSet() {
            return Builder<Customer>.CreateListOfSize(2).Build().ToList();
        }
    }
}