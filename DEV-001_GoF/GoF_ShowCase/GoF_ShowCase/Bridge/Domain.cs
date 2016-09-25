namespace GoF_ShowCase.Bridge {
    public class ItemInCart {
        public uint Id { get; set; }
        public uint Quantity { get; set; }
        public Money Price { get; set; }
    }


    public class Money {
        public int Value { get; set; }

        public CurrencyType Currency { get; set; }

        public void Add(Money price) {
            throw new System.NotImplementedException();
        }

        public static Money operator *(Money money, uint multiplier) {
            return money;
        }

        public static Money operator *(Money money, double multiplier) {
            return money;
        }
    }

    public enum CurrencyType {
        RUR
    }

    public class Address {}
}