namespace GoF_TryOut.Adapter.StraightCode {
    public class ClientCode {
        public ClientCode() {
            var customers = new CustomerRepo().GetCustomers(10);
            var orders = new OrderRepo().GetOrders(100, customers[0]);
        }
    }
}