using System;
using System.Collections.Generic;

namespace GoF_TryOut.Interpreter.Refactored {
    public class Customer {
        public string Name { get; set; }
        public Importance Importance { get; set; }
        public string Country { get; set; }
    }

    public class CustomerCountrySpec : Specification<Customer> {
        public readonly string country;

        public CustomerCountrySpec(string country) {
            this.country = country;
        }

        public override bool IsSatisfiedBy(Customer obj) {
            return country == obj.Country;
        }
    }

    public class CustomerNameStartsFromSpec : Specification<Customer> {
        private readonly string nameTemplate;

        public CustomerNameStartsFromSpec(string nameTemplate) {
            this.nameTemplate = nameTemplate;
        }

        public override bool IsSatisfiedBy(Customer obj) {
            return obj.Name.StartsWith(nameTemplate);
        }
    }

    public enum Importance {
        Regular,
        Returning,
        Vip,
        Global
    }

    public class BusinessLogic {
        private readonly Repository repository;

        public BusinessLogic(Repository repository) {
            this.repository = repository;
        }

        public List<Customer> GetCustomerBy(Specification<Customer> specification) {
            return repository.GetCustomersBy(specification);
        }
    }

    public class ClientForm {
        public ClientForm() {
            var repo = new Repository();
            var businessLogic = new BusinessLogic(repo);

            var res1 = businessLogic.GetCustomerBy(new CustomerCountrySpec("USA"));
            foreach (var customer in res1) {
                Console.WriteLine(customer.Name + " " + customer.Country);
            }

            var res2 = businessLogic.GetCustomerBy(new CustomerCountrySpec("United Kingdome")
                                                   & new CustomerNameStartsFromSpec("B"));

            foreach (var customer in res2) {
                Console.WriteLine(customer.Name + " " + customer.Country);
            }
        }
    }
}