using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Adapter.StraightCode {
    public class OrderRepo {
        private readonly DbAccessor dbAccessor;
        private readonly Table<Order> table;

        public OrderRepo() {
            dbAccessor = new DbAccessor();
            table = dbAccessor.GetTable<Order>();
        }

        public List<Order> GetOrders(int top) {
            var result = dbAccessor.Select(table.Take(top));

            return result;
        }

        public List<Order> GetOrders(int top, Customer customer) {
            var query = table.Take(top).Where(o => o.Customer.Id == customer.Id);
            var result = dbAccessor.Select(query);

            return result;
        }
    }
}