using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Transaction
    {
        public double TransactionAmount { get; set; }
        public DateTime DateTime { get; set; }

        public Transaction(double transactionAmount, DateTime dateTime)
        {
            TransactionAmount = transactionAmount;
            DateTime = dateTime;
        }
    }
}
