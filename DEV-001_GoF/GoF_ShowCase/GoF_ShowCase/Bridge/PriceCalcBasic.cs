using System.Collections.Generic;

namespace GoF_ShowCase.Bridge {
     // Переходим к воплощению абстракций. Базовый вариант будет просто вычислять цену без учета скидок

    public class PriceCalcBasic : IPriceCalc {
        private readonly IPriceCalcImpl impl;

        private readonly Dictionary<uint, ItemInCart> cart = new Dictionary<uint, ItemInCart>();

        public PriceCalcBasic(IPriceCalcImpl impl) {
            this.impl = impl;
        }

        public virtual void AddItem(uint itemId, uint itemQuantity) {
            var item = new ItemInCart {Id = itemId, Quantity = itemQuantity};
            cart.Add(itemId, item);
        }

        public virtual Money GetTotalPrice(Address shippingTo) {
            var sum = new Money();
            var itemsList = cart.Values;

            foreach (var item in itemsList) {
                var itemPrice = impl.GetItemPrice(item.Id, item.Quantity);
                item.Price = itemPrice * item.Quantity;

                sum.Add(item.Price);
            }

            var shippingPrice = impl.GetShippingPrice(
                itemsList.GetEnumerator(), shippingTo);

            sum.Add(shippingPrice);

            return sum;
        }
    }
}