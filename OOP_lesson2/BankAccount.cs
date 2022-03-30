using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lesson2
{
    public class BankAccount
    {
        private int accountNumber;
        private int balance;
        public enum accountType
        {
            currency,
            accumulative,
            frozen,
            budget,
            insured
        };

        private accountType type;

        //public int GetBalance()
        //{
        //    return balance;
        //}
        public int Balance { get; set; }
        public BankAccount()
        {

        }
        public BankAccount(int balance)
        {
            this.balance = balance;
            this.accountNumber = GenerateAccountNumber();
        }
        //public void SetBalance(int balance)
        //{
        //    this.balance = balance;
        //}


        //public void SetAccountNumber(int accountNumber)
        //{
        //    this.accountNumber = accountNumber;
        //}
        public int AccountNumber {get;set;}
        //public accountType GetAccountType()
        //{
        //    return type;
        //}
        public accountType AccountType { get; set; }
        public BankAccount(accountType type)
        {
            this.type = type;
            this.accountNumber = GenerateAccountNumber();
        }
        public BankAccount(accountType type, int balance)
        {
            this.balance = balance;
            this.type = type;
            this.accountNumber = GenerateAccountNumber();
        }
        public override string ToString()
        {
            return $"accountNumber:{accountNumber}, balance:{balance}, type:{type}";
        }
        //  public void SetAccountType(accountType type)
        //{
        //    this.type = type;
        //}
        private static int generatedAccountNumber = 1243456546;

        public static int GenerateAccountNumber()
        {
            generatedAccountNumber += 1;
            return generatedAccountNumber;
        }
        public int GeneratedAccountNumber 
        { 
            get 
            {
                generatedAccountNumber += 1;
                return generatedAccountNumber;
            }
        }
        /// <summary>
        /// метод для уменьшения баланса на определенную сумму
        /// </summary>
        /// <param name="account">счет, с которого будет списана сумма</param>
        /// <param name="sum">сумма для списания</param>
        /// <returns></returns>
        public static int WithdrawFunds(BankAccount account, int sum)
        {
            if (account.Balance<sum)
            {
                Console.WriteLine("Недостаточно средств на счете");
                return 0;
            }
            return account.Balance - sum;           
        }

    }
}
