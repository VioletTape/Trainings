namespace GoF_TryOut.Decorator.Refactored {
    public class User {
        public Role Role { get; set; }
    }

    public enum Role {
        Ordinary,
        Preffered,
        Vip,
        Exclusive
    }

    public class Log {
        public void Write(string message) {}
    }

    public class Address {
        public string Country { get; set; }
        public string State { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}