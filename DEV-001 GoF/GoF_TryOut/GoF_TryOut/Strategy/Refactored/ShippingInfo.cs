using System.Collections.Generic;

namespace GoF_TryOut.Strategy.Refactored {
    public class ShippingInfo {
        private IDictionary<State, IShippingCalculation> ShippingCalculations { get; set; }

        public ShippingInfo() {
            ShippingCalculations = new Dictionary<State, IShippingCalculation> {
                {State.Alaska, new AlaskShippingCalculation()},
                {State.NewYork, new NewYorkShippingCalculation()},
                {State.Florida, new FloridaShippingCalculation()}
            };
        }

        public decimal CalculateShippingAmount(State shipToState) {
            return ShippingCalculations[shipToState].Calculate();
        }
    }
}