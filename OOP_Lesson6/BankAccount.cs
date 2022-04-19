using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lesson6
{
    public class BankAccount
    {
        public enum accountType
        {
            currency,
            accumulative,
            frozen,
            budget,
            insured
        };
        public int AccountNumber { get; set; }

        public int Balance { get; set; }
        public accountType AccountType { get; set; }

        public BankAccount()
        {

        }
        public BankAccount(int balance)
        {
            Balance = balance;
            AccountNumber = GenerateAccountNumber();
        }
        public BankAccount(accountType type)
        {
            AccountType = type;
            AccountNumber = GenerateAccountNumber();
        }
        public BankAccount(accountType type, int balance)
        {
            Balance = balance;
            AccountType = type;
            AccountNumber = GenerateAccountNumber();
        }
        public override string ToString()
        {
            return $"accountNumber:{AccountNumber}, balance:{Balance}, type:{AccountType}";
        }

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

        public static bool operator == (BankAccount a, BankAccount b)
        {
            if (a.AccountNumber == b.AccountNumber &&
                a.Balance == b.Balance &&
                a.AccountType == b.AccountType)
            {
                return true;
            }
            return false;
        }
             
        public static bool operator != (BankAccount a, BankAccount b)
        {
            if (a.AccountNumber != b.AccountNumber ||
                a.Balance != b.Balance ||
                a.AccountType != b.AccountType)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            var other = (BankAccount)obj;

            if (this.AccountNumber == other.AccountNumber &&
                this.Balance == other.Balance &&
                this.AccountType == other.AccountType)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode() => (AccountNumber, AccountType, Balance).GetHashCode();
        
    }
}
