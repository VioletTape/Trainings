using System.Collections.Generic;

namespace GoF_ShowCase.Bridge {
    // Создадим уточнение – расчет цены с учетом скидок для постоянных клиентов. Будем использовать наследование от базового интерфейса
    public class PriceCalcDiscount : IPriceCalc {
        private readonly IPriceCalcImpl impl;

        private readonly Dictionary<uint, ItemInCart> cart = new Dictionary<uint, ItemInCart>();

        public PriceCalcDiscount(DeliveryCompany company) {
            impl = PriceCalcImplFabric.GetPriceCalcImpl(company);
        }

        public virtual void AddItem(uint itemId, uint itemQuantity) {
            var item = new ItemInCart {Id = itemId, Quantity = itemQuantity};
            cart.Add(itemId, item);
        }

        public virtual Money GetTotalPrice(Address shippingTo) {
            var sum = new Money();
            var itemsList = cart.Values;

            foreach (var item in itemsList) {
                var itemPrice = impl.GetItemPrice(item.Id, item.Quantity)*0.7;
                if (item.Quantity > 10) {
                    itemPrice = itemPrice*0.95f;
                }

                item.Price = itemPrice*item.Quantity;
                sum.Add(item.Price);
            }

            var shippingPrice = impl.GetShippingPrice(itemsList.GetEnumerator(), shippingTo);

            sum.Add(shippingPrice);

            return sum;
        }
    }
}