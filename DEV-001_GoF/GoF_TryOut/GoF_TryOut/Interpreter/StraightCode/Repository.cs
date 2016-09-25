using System.Collections.Generic;

namespace GoF_TryOut.Interpreter.StraightCode {
    public class Repository {
        private List<Customer> customer;

        public Repository() {
            customer = new List<Customer> {
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

        public List<Customer> GetCustomers() {
            return customer;
        }
    }
}