using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Transaction
    {
        public decimal TransactionAmount { get; set; }
        public DateTime DateTime { get; set; }
        private Account _account;
        public Transaction(decimal transactionAmount, DateTime dateTime)
        {
            TransactionAmount = transactionAmount;
            DateTime = dateTime;
        }

        public void DisplayListOfTransactions(Account account)
        {
            _account = account;
            Console.WriteLine($"{_account.AccountType} {_account.AccountID} {_account.Balance}");

        }
    }
}
