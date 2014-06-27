namespace GoF_TryOut.State.Refactored {
    public class Account {
        internal CardState State;

        public Account() {
            State = new StandardCardState(0, this);
        }

        public void Withdraw(decimal amount) {
            State.Withdraw(amount);
        }


        public void Deposit(decimal amount) {
            State.Deposit(amount);
        }

        public string GetState() {
            return "";
        }
    }
}