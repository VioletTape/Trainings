namespace GoF_TryOut.Strategy.Refactored {
    public class FloridaShippingCalculation : IShippingCalculation {
        public decimal Calculate() {
            return 3m;
        }
    }
}