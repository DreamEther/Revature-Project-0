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
            if (deposit <= 0 )
            {
                Console.WriteLine("Deposit must be greater than 0");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
                string depositString = deposit.ToString();
                DepositString = "+$" + depositString;
                String.Format("{0:0.00}", DepositString);
                DepositAmount = deposit;
                DateOfTransaction = dateTime;
                Balance += DepositAmount;
                decimal roundedBalance = Decimal.Round(Balance, 2);
                Balance = roundedBalance;
                var completeDeposit = new Transaction(Balance, DepositString, DepositAmount, DateOfTransaction);
                transactions.Add(completeDeposit);
        }   
        public abstract void MakeWithdrawal(decimal withdrawal, DateTime dateTime);
    }
}
