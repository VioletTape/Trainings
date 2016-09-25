using System.Collections;

namespace GoF_ShowCase.Bridge {
    public class PriceCalcCompanyAImpl : PriceCalcBaseImpl {
        public override Money GetShippingPrice(IEnumerator cart, Address shippingTo) {
            /* Skipped */

            return new Money();
        }
    }
}