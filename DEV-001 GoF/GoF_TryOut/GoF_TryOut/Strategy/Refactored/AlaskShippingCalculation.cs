namespace GoF_TryOut.Strategy.Refactored {
    public class AlaskShippingCalculation : IShippingCalculation {
        public decimal Calculate() {
            return 15m;
        }
    }
}