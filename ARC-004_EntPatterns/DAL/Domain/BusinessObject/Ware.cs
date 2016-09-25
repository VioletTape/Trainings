using System;

namespace Domain {
    public class Ware {
        public Guid WareId;
        public string Title;
        public decimal Price;
        public int Quantity;

        public Ware WithQuantity(int quantity) {
            return new Ware {
                                WareId = WareId,
                                Title = Title,
                                Price = Price,
                                Quantity = quantity
                            };
        }
    }
}