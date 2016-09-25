namespace GoF_TryOut.Strategy.Refactored {
    public class NewYorkShippingCalculation : IShippingCalculation {
        public decimal Calculate() {
            return 10m;
        }
    }
}