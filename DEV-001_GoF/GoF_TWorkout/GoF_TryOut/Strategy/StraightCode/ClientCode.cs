namespace GoF_TryOut.Strategy.StraightCode {
    public class ClientCode {
        public decimal CalculateShipping() {
            var shippingInfo = new ShippingInfo();
            return shippingInfo.CalculateShippingAmount(State.Alaska);
        }
    }
}