using System;

namespace GoF_TryOut.State.Refactored {
    internal abstract class CardState {
        protected decimal balance;
        protected readonly Account account;

        public CardState(decimal balance, Account account) {
            this.balance = balance;
            this.account = account;
        }

        public decimal GetBalance() {
            return balance;
        }

        internal void Withdraw(decimal amount) {
            if (balance >= amount) {
                balance -= amount;
                balance -= GetWithdrawFee(amount);
                CheckBalance();
            }
            else {
                throw new InvalidOperationException("Your balance is too low");
            }
        }

        protected abstract decimal GetWithdrawFee(decimal amount);

        internal void Deposit(decimal amount) {
            balance += amount;
            CheckBalance();
        }

        internal abstract void CheckBalance();

        internal abstract int GetDiscountPercent();

        public abstract decimal PayInterest();

        public abstract string GetStateName();
    }
}