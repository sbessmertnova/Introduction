using System;

namespace OOP_lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //task 1
            var userBankAccount = new BankAccount();
            //userBankAccount.SetAccountNumber(1);
            //userBankAccount.SetAccountType(BankAccount.accountType.budget);
            //userBankAccount.SetBalance(100);
            //Console.WriteLine($"AccountInfo:" +
            //    $"\nType: {userBankAccount.GetAccountType()};" +
            //    $"\nNumber: {userBankAccount.GetAccountNumber()};" +
            //    $"\nBalance: {userBankAccount.GetBalance()}.");
            Console.ReadKey();

            //task 2
            Console.WriteLine($"autogenereted account number: {BankAccount.GenerateAccountNumber()}");
            Console.ReadKey();

            //task 3
            //var balance = userBankAccount.GetBalance();
            //var type = userBankAccount.GetAccountType();
            //var accountInfo = new BankAccount(type, balance);
            //Console.WriteLine($"{accountInfo}");
            Console.ReadKey();

            //task 4
            userBankAccount.AccountType = BankAccount.accountType.frozen;
            userBankAccount.Balance = 300;
            userBankAccount.AccountNumber = 3;
            Console.WriteLine($"\nAccountType:{userBankAccount.AccountType}" +
                $"\nBalance:{userBankAccount.Balance}" +
                $"\nAccountNumber:{userBankAccount.AccountNumber}");
            var newAccountNumber = userBankAccount.GeneratedAccountNumber;

            Console.WriteLine($"\nnewAccountNumber:{newAccountNumber}");
            Console.ReadKey();

        }
    }
}
