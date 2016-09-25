namespace GoF_TryOut.State.Refactored {
    internal class StandardCardState : CardState {
        public StandardCardState(decimal balance, Account account) : base(balance, account) {}

        protected override decimal GetWithdrawFee(decimal amount) {
            return amount*0.015m;
        }

        internal override void CheckBalance() {
            if (balance > 10000) {
                account.State = new GoldState(balance, account);
            }
        }

        internal override int GetDiscountPercent() {
            return 3;
        }

        public override decimal PayInterest() {
            return balance*1.05m;
        }

        public override string GetStateName() {
            return "standard";
        }
    }
}