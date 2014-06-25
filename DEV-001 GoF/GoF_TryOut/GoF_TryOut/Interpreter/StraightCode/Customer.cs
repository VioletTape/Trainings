using System;
using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Interpreter.StraightCode {
    public class Customer {
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public string Country { get; set; }
    }

    public enum Importance {
        Regular,
        Returning,
        Vip,
        Global
    }

    public class BusinessLogic {
        private Repository repository;

        public BusinessLogic(Repository repository) {
            this.repository = repository;
        }

        public List<Customer> GetCustomersFrom(string country) {
           return repository.GetCustomers()
                      .Where(c => c.Country == country)
                      .Select(c => c)
                      .ToList();
        }

        public List<Customer> GetCustomersFromAndNameStartingFrom(string country, string nameFrom) {
            return repository.GetCustomers()
                      .Where(c => c.Country == country && c.Name.StartsWith(nameFrom))
                      .Select(c => c)
                      .ToList();
        } 
        
    }

    public class ClientForm {
        public ClientForm() {
            var repo = new Repository();
            var businessLogic = new BusinessLogic(repo);

            var res1 = businessLogic.GetCustomersFrom("USA");
            foreach (var customer in res1) {
                Console.WriteLine(customer.Name + " " + customer.Country);
            }

            var res2 = businessLogic.GetCustomersFromAndNameStartingFrom("United Kingdome", "B");
            foreach (var customer in res2) {
                Console.WriteLine(customer.Name + " " + customer.Country);
            }

        }
    }
}