using System;

namespace OOP_Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstBankAccount = new BankAccount(BankAccount.accountType.budget, 1000);
            var secondBankAccount = new BankAccount(BankAccount.accountType.currency, 2000);
            var thirdBankAccount = new BankAccount()
            {
                AccountNumber = 1,
                AccountType = BankAccount.accountType.frozen,
                Balance = 3000
            };
            var fourthBankAccount = new BankAccount()
            {
                AccountNumber = 1,
                AccountType = BankAccount.accountType.frozen,
                Balance = 3000
            };

            //Сравнение первого и второго аккаунтов с помощью ==
            if (firstBankAccount == secondBankAccount)
            {
                Console.WriteLine($"First bank account {firstBankAccount} matches  second bank account {secondBankAccount}");

            }
            else
            {
                Console.WriteLine($"First bank account {firstBankAccount} and  second bank account {secondBankAccount} don't match");
            }

            //Сравнение третьего и четвертого аккаунтов с помощью !=
            if (thirdBankAccount != fourthBankAccount)
            {
                Console.WriteLine($"Third bank account {thirdBankAccount} and  fourth bank account {fourthBankAccount} don't match");

            }
            else
            {
                Console.WriteLine($"Third bank account {thirdBankAccount} matches  fourth bank account {fourthBankAccount}");
            }

            //Сравнение первого и второго аккаунтов с помощью Equals
            if (firstBankAccount.Equals(secondBankAccount))
            {
                Console.WriteLine($"First bank account {firstBankAccount} matches  second bank account {secondBankAccount}");

            }
            else
            {
                Console.WriteLine($"First bank account {firstBankAccount} and  second bank account {secondBankAccount} don't match");
            }

            //Сравнение третьего и четвертого аккаунтов с помощью Equals
            if (thirdBankAccount.Equals(fourthBankAccount))
            {
                Console.WriteLine($"Third bank account {thirdBankAccount} matches  fourth bank account {fourthBankAccount}");
            }
            else
            {
                Console.WriteLine($"Third bank account {thirdBankAccount} and  fourth bank account {fourthBankAccount} don't match");
            }
            //Сравнение первого и второго аккаунтов с помощью GetHashCode
            if (firstBankAccount.GetHashCode()== secondBankAccount.GetHashCode())
            {
                Console.WriteLine($"First bank account {firstBankAccount} matches  second bank account {secondBankAccount}");

            }
            else
            {
                Console.WriteLine($"First bank account {firstBankAccount} and  second bank account {secondBankAccount} don't match");
            }

            //Сравнение третьего и четвертого аккаунтов с помощью GetHashCode
            if (thirdBankAccount.GetHashCode()== fourthBankAccount.GetHashCode())
            {
                Console.WriteLine($"Third bank account {thirdBankAccount} matches  fourth bank account {fourthBankAccount}");
            }
            else
            {
                Console.WriteLine($"Third bank account {thirdBankAccount} and  fourth bank account {fourthBankAccount} don't match");
            }

            Console.ReadKey();
            
        }

    }
}

