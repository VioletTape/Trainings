namespace GoF_TryOut.State.Straight {
    public class Example {
        public Example()
        {
            var account = new Account();
            account.Deposit(1000000);
            account.Withdraw(500);
            account.Withdraw(500);
            account.Withdraw(990000);
        }
    }

    public enum CardType {
        Standard,
        Gold,
        Platinum
    }
}