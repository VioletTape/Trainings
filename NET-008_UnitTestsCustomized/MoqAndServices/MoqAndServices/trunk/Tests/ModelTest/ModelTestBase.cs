using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.Models;
using Application.Services;
using Application.Services.Interfaces;
using Moq;
using NUnit.Framework;
using StructureMap;
using Tests.Fakes;

namespace Tests.ModelTest {
    public class ModelTestBase {
        protected Mock<OrderService> OrderService;
        protected Mock<CustomerLoadService> CustomerService;

        internal Task<List<Customer>> loadAllCustomersResults;
        internal Task<List<Order>> loadOrdersByResults;

        internal Model Model;

        [TestFixtureSetUp]
        public void BaseClassSetup() {
            ObjectFactory.Configure(x => x.For<IDataFacade>().Use<FakeFacade>());

            CustomerService = new Mock<CustomerLoadService>();
            OrderService = new Mock<OrderService>();
        }

        [SetUp]
        public void BaseSetup() {
            Model = new Model();

            CustomerService.As<ICustomerLoadService>();
            OrderService.As<IOrderService>();

            CustomerService.As<ICustomerLoadService>()
                .Setup(i => i.LoadAllCustomersAsync())
                .Returns(LoadAllCustomersResults);
//                           .Raises(x => x.CustomersLoaded += null, loadAllCustomersResults);

            OrderService.As<IOrderService>()
                        .Setup(i => i.LoadOrdersByAsync(Model.SelectedCustomer))
                        .Returns(LoadOrdersByResult);

            ObjectFactory.Configure(x => {
                x.For<IOrderService>().Use(OrderService.Object);
                x.For<ICustomerLoadService>().Use(CustomerService.Object);
            });
        }

        public virtual Task<List<Customer>> LoadAllCustomersResults() {
            loadAllCustomersResults = new Task<List<Customer>>(CustomerSet);
            loadAllCustomersResults.Start();
            loadAllCustomersResults.Wait();

            return loadAllCustomersResults;
        }

        public virtual List<Customer> CustomerSet() {
            return new List<Customer>();
        }


        public virtual Task<List<Order>> LoadOrdersByResult() {
            loadOrdersByResults = new Task<List<Order>>(OrderSet);
            loadOrdersByResults.Start();
            loadOrdersByResults.Wait();

            return loadOrdersByResults;
        }

        public virtual List<Order> OrderSet() {
            return new List<Order>();
        }
    }
}