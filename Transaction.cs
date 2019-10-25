using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Transaction
    {

        public decimal TransactionAmount { get; set; }
        public DateTime DateTime { get; set; }
        public string TransactionAsString { get; set; }

        public decimal newBalance;
        public Transaction(decimal balance, string amount, decimal transactionAmount, DateTime dateTime)
        {
            newBalance = balance;
            TransactionAsString = amount;
            TransactionAmount = transactionAmount;
            DateTime = dateTime;
        }

        //public void DisplayListOfTransactions(Account account)
        //{
        //    _account = account;
        //    Console.WriteLine($"{_account.AccountType} {_account.AccountID} {_account.Balance}");

        //}
    }
}
