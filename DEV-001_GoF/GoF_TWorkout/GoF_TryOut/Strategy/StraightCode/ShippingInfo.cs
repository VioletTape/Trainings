namespace GoF_TryOut.Strategy.StraightCode {
    public class ShippingInfo {
        public decimal CalculateShippingAmount(State shipToState) {
            switch (shipToState) {
                case State.Alaska:
                    return GetAlaskaShippingAmount();
                case State.NewYork:
                    return GetNewYorkShippingAmount();
                case State.Florida:
                    return GetFloridaShippingAmount();
                default:
                    return 0m;
            }
        }

        private decimal GetAlaskaShippingAmount() {
            return 15m;
        }

        private decimal GetNewYorkShippingAmount() {
            return 10m;
        }

        private decimal GetFloridaShippingAmount() {
            return 3m;
        }
    }
}