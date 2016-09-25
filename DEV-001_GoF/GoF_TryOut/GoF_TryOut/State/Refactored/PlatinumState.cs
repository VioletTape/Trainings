namespace GoF_TryOut.State.Refactored {
    internal class PlatinumState : CardState {
        public PlatinumState(decimal balance, Account account) : base(balance, account) {}

        protected override decimal GetWithdrawFee(decimal amount) {
            return 0;
        }

        internal override void CheckBalance() {
            if (balance < 100000) {
                account.State = new GoldState(balance, account);
            }
        }

        internal override int GetDiscountPercent() {
            return 12;
        }

        public override decimal PayInterest() {
            return balance*1.11m;
        }

        public override string GetStateName()
        {
            return "platinum";
        }
    }
}