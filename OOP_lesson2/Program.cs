using System;
using System.Collections.Generic;

namespace OOP_lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //task 1      
            Console.WriteLine("Сумма перевода:");
            if (!int.TryParse(Console.ReadLine(), out var userInput))
            {
                Console.WriteLine($"Введенные данные не являются числом");
            }
            var userBankAccount = new BankAccount()
            {
                Balance = 1000
            };
            userBankAccount.Balance = BankAccount.WithdrawFunds(userBankAccount, userInput);
            Console.WriteLine($"Account funds: {userBankAccount.Balance}");
            Console.ReadKey();
            //task2
            Console.WriteLine("Введите слово:");
            var userWord = Console.ReadLine();
            Console.WriteLine($"Слово {userWord} наоборот: {FlipWord(userWord)}");
            Console.ReadKey();

        }
        public static string FlipWord(string userInput)
        {
            var lettersNumber = userInput.Length;
            var newWords = new List<char>();           
            for (int i = 1; i <= lettersNumber; i++)
            {
                 newWords.Add(userInput[lettersNumber - i]);
            }
            return new string(newWords.ToArray());
        }

    }
}
