using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public abstract class Account
    {
        public decimal WithdrawalAmount { get; set; }
        public double CustomerID { get; set; }
        public decimal DepositAmount { get; set; }
        public decimal InterestRate { get; set; }
        public string AccountType { get; set; }

        public string WithdrawalString { get; set; }

        public string DepositString { get; set; }
        public List<Transaction> transactions = new List<Transaction>();
        public List<String> transactionsAsString = new List<string>();
        public int AccountID { get; set; }
        public decimal Balance { get; set; }

        public DateTime DateOfTransaction { get; set; }

        public virtual void MakeDeposit(decimal deposit, DateTime dateTime)
        {
            string depositString = deposit.ToString();
            DepositString = "+$" + depositString;
            DepositAmount = deposit;
            DateOfTransaction = dateTime;
            Balance += DepositAmount;
            var completeDeposit = new Transaction(Balance, DepositString, DepositAmount, DateOfTransaction);
            transactions.Add(completeDeposit);
        }

        public abstract void MakeWithdrawal(decimal withdrawal, DateTime dateTime);

    }
}
