using System;
using System.Collections.Generic;

namespace GoF_TryOut.State.Straight {
    public class Account {
        private CardType cardType;
        private decimal balance;
        private decimal withdrawCount;


        private readonly Dictionary<CardType, decimal> lowerLimit = new Dictionary<CardType, decimal> {
            {CardType.Standard, 0},
            {CardType.Gold, 10000.01m},
            {CardType.Platinum, 100000.01m}
        };

        private readonly Dictionary<CardType, decimal> upperLimit = new Dictionary<CardType, decimal> {
            {CardType.Standard, 10000},
            {CardType.Gold, 100000},
            {CardType.Platinum, decimal.MaxValue}
        };

        public void ChangeCardType(CardType cardType) {
            cardType = cardType;
        }

        public string GetStateName()
        {
            return cardType.ToString();
        }

        public decimal GetBalance() {
            return balance;
        }

        public void Withdraw(decimal amount) {
            if (balance >= amount) {
                balance -= amount;

                var fee = 0m;
                switch (cardType) {
                    case CardType.Standard:
                        fee = amount*0.015m;
                        break;
                    case CardType.Gold:
                        if (withdrawCount < 10) {
                            fee = 0;
                        }
                        withdrawCount++;
                        fee = amount*0.01m;
                        break;

                    case CardType.Platinum:
                        fee = 0;
                        break;
                }
                balance -= fee;

                CheckBalance();
            }
            else {
                throw new InvalidOperationException("Your balance is too low");
            }
        }

        public void Deposit(decimal amount) {
            balance += amount;
            CheckBalance();
        }

        private void CheckBalance() {
            if (lowerLimit[CardType.Standard] <= balance && balance <= upperLimit[CardType.Standard]) {
                cardType = CardType.Standard;
            }

            if (lowerLimit[CardType.Gold] <= balance && balance <= upperLimit[CardType.Gold]) {
                cardType = CardType.Gold;
            }

            if (lowerLimit[CardType.Platinum] <= balance && balance <= upperLimit[CardType.Platinum]) {
                cardType = CardType.Platinum;
            }
        }

        public int GetDiscountPercent() {
            switch (cardType) {
                case CardType.Standard:
                    return 3;
                case CardType.Gold:
                    return 7;
                case CardType.Platinum:
                    return 12;
            }
            return 0;
        }

        public decimal PayInterest() {
            var interest = 0m;
            switch (cardType) {
                case CardType.Standard:
                    interest = 0.05m;
                    break;
                case CardType.Gold:
                    interest = 0.08m;
                    break;
                case CardType.Platinum:
                    interest = 0.1m;
                    break;
            }

            return balance*(1 + interest);
        }
    }
}