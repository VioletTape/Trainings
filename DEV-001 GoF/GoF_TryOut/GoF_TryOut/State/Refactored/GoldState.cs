namespace GoF_TryOut.State.Refactored {
    internal class GoldState : CardState {
        private int withdrawCount;

        public GoldState(decimal balance, Account account) : base(balance, account) {
            CheckBalance();
        }

        protected override decimal GetWithdrawFee(decimal amount) {
            if (withdrawCount < 10) {
                return 0;
            }
            withdrawCount++;
            return amount*0.01m;
        }

        internal override void CheckBalance() {
            if (balance > 100000) {
                account.State = new PlatinumState(balance, account);
            }
            if (balance < 10000) {
                account.State = new StandardCardState(balance, account);
            }
        }

        internal override int GetDiscountPercent() {
            return 7;
        }

        public override decimal PayInterest() {
            return balance*1.08m;
        }

        public override string GetStateName()
        {
            return "gold";
        }
    }
}