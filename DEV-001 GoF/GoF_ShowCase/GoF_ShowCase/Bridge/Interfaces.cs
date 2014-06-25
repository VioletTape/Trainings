using System.Collections;

namespace GoF_ShowCase.Bridge {
    public interface IPriceCalc {
        void AddItem(uint itemId, uint itemQuantity);
        Money GetTotalPrice(Address shippingTo);
    }

    public interface IPriceCalcImpl {
        Money GetItemPrice(uint itemId, uint itemQuantity);
        Money GetShippingPrice(IEnumerator cart, Address shippingTo);
    }
}