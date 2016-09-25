using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Adapter.StraightCode {
    public class CustomerRepo {
        private readonly DbAccessor dbAccessor;
        private readonly Table<Customer> table;

        public CustomerRepo() {
            dbAccessor = new DbAccessor();
            table = dbAccessor.GetTable<Customer>();
        }

        public List<Customer> GetCustomers(int top) {
            var result = dbAccessor.Select(table.Take(top));

            return result;
        }

        public List<Customer> GetCustomers(int top, string nameStartsFrom) {
            var query = table.Take(top).Where(c => c.Name.StartsWith(nameStartsFrom));
            var result = dbAccessor.Select(query);

            return result;
        }
    }
}