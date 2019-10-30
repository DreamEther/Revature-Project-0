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

        public decimal NewBalance { get; set; }
        public Transaction(decimal balance, string amountAsString, decimal transactionAmount, DateTime dateTime)
        {
            NewBalance = balance;
            TransactionAsString = amountAsString;
            TransactionAmount = transactionAmount;
            DateTime = dateTime;
        }
    }
}
