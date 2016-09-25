using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Interpreter.Refactored {
    public class Repository {
        private List<Customer> customers;

        public Repository() {
            customers = new List<Customer> {
                                               new Customer {
                                                                Name = "Acme",
                                                                Importance = Importance.Global,
                                                                Country = "USA"
                                                            },
                                               new Customer {
                                                                Name = "Gazprom",
                                                                Importance = Importance.Global,
                                                                Country = "Russia"
                                                            },
                                               new Customer {
                                                                Name = "Little pony",
                                                                Importance = Importance.Regular,
                                                                Country = "USA"
                                                            },
                                               new Customer {
                                                                Name = "Big fun",
                                                                Importance = Importance.Returning,
                                                                Country = "United Kingdome"
                                                            },
                                               new Customer {
                                                                Name = "Birmingham",
                                                                Importance = Importance.Vip,
                                                                Country = "United Kingdome"
                                                            },
                                               new Customer {
                                                                Name = "Vasiliy & Co",
                                                                Importance = Importance.Returning,
                                                                Country = "Russia"
                                                            }
                                           };
        }

        public List<Customer> GetCustomersBy(Specification<Customer> specs) {
            return customers.Where(specs.IsSatisfiedBy)
                            .Select(c => c)
                            .ToList();
        }
    }
}