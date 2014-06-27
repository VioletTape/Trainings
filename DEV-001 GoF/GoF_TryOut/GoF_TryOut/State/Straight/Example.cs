using System;

namespace GoF_TryOut.State.Straight {
    public class Example {
        public Example()
        {
            var account = new Account();
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Deposit(1000000);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(500);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(900000);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(90000);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(200);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(200);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(200);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(200);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(200);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());

            account.Withdraw(200);
            Console.WriteLine("Balance: " + account.GetBalance());
            Console.WriteLine("Type: " + account.GetStateName());
        }
    }

    public enum CardType {
        Standard,
        Gold,
        Platinum
    }
}