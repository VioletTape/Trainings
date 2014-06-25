using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
using Application.Services.Interfaces;
using StructureMap;

namespace Application.Models {
    public class Model {
        private IOrderService orderService;
        private ICustomerLoadService customerLoadService;
        private Task<List<Customer>> customerLoadedTask;
        private List<Customer> customers;
        private Task<List<Order>> orderLoadTask;
        private List<Order> orders;

        public Action<string> Print { get; set; }
        public Action<string> OnAnswer { get; set; }
        public Func<string> Answer { get; set; }
        
        public Customer SelectedCustomer;

        public void InitModel() {
            orderService = ObjectFactory.GetInstance<IOrderService>();
            customerLoadService = ObjectFactory.GetInstance<ICustomerLoadService>();

            OnAnswer = ProcessMainMenu;

            Print("Welcome");

            PrintMenu();
        }

        public void ProcessAnswer(string obj) {
            OnAnswer(obj);
        }

public void ProcessMainMenu(string obj) {
    switch (obj) {
        case "1":
            Print("Customers Selected and loading...");
            customerLoadService.CustomersLoaded += CustomersLoadLoaded;
            customerLoadedTask = customerLoadService.LoadAllCustomersAsync();
            OnAnswer = SelectCustomer;

            break;
        case "2":
            Print("Orders Selected");
            orderService.OrdersLoaded += OrdersLoaded;
            orderLoadTask = orderService.LoadOrdersByAsync(SelectedCustomer);
            OnAnswer = ProcessMainMenu;
            break;
        case "3":
            Print("Items Selected");
            break;
    }
}

private void CustomersLoadLoaded(Task obj) {
    if(customerLoadedTask != obj) return;

    customerLoadService.CustomersLoaded -= CustomersLoadLoaded;
    customers = customerLoadedTask.Result;

    for (var i = 0; i < customers.Count; i++) {
        Print(string.Format("{0}. {1}", i, customers[i].Name));
    }
    Print("Select Customer");
}

        private void SelectCustomer(string obj) {
            var i = Convert.ToInt32(obj);
            SelectedCustomer = customers[i];

            Print("");
            Print(string.Format("Selected customer {0}", SelectedCustomer.Name));
            PrintMenu();
                    OnAnswer = ProcessMainMenu;

        }


        private void OrdersLoaded(Task obj) {
            orderService.OrdersLoaded += OrdersLoaded;
            orders = orderLoadTask.Result;
            Print("orders for customer");

            for (var i = 0; i < orders.Count; i++) {
                Print(string.Format("{0}. {1} {2}", i, orders[i].RefNumber, orders[i].CreateTime));
            }

            PrintMenu();
        }


        private void PrintMenu() {
            var strings = new List<string> {
                                               "",
                                               "Select option:",
                                               "--------------------------------------------------",
                                               "1. Get Customers",
                                               "2. Get Orders",
                                               "3. Get Items",
                                               ""
                                           };

            strings.ForEach(Print);
        }
    }
}