using System.Collections;

namespace GoF_ShowCase.Bridge {
    public class PriceCalcBaseImpl : IPriceCalcImpl {
        public virtual Money GetItemPrice(uint itemId, uint itemQuantity) {
            /* Skipped */
            return new Money();
        }

        public virtual Money GetShippingPrice(IEnumerator cart, Address shippingTo) {
            return new Money {
                Value = 0,
                Currency = CurrencyType.RUR
            };
        }
    }
}