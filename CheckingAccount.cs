using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class CheckingAccount : IAccount
    {
        public List<Transaction> transactions = new List<Transaction>();
        public double InterestRate { get; set; }
        
        public Customer CustomerID { get; set; }
        public DateTime TermDepositStartDate { get; set; }
        public int AccountID { get; set; }
        public double Balance { get; set; }

        public void MakeDeposit(double deposit, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void MakeTermDeposit(double deposit, DateTime dateTime)
        {
            if (deposit <= 0)
            {
                throw new System.ArgumentException("Deposit amount must be positive");
            }
            else if (deposit > 0)
            {
                Balance += deposit;
            }
            var completeDeposit = new Transaction(deposit, dateTime);
            transactions.Add(completeDeposit);
        }

        public void MakeTermWithdrawal(double withdrawal, DateTime dateTime)
        {
            if (withdrawal <= 0)
            {
                throw new System.ArgumentException("Withdrawal amount must be positive.");
            }
            else if (withdrawal > 0)
            {
                double newBalance = Balance - withdrawal;
                if(newBalance < 0)
                {
                    throw new System.ArgumentException("You do not have sufficient funds for this withdrawal.");
                }
            }
        }

        public void MakeWithdrawal(double withdrawal, DateTime dateTime)
        {

            throw new NotImplementedException();
        }

        public void OpenAccount()
        {

        }
        //public void Deposit(double deposit)
        //{
        //    DepositAmount = deposit;
        //    Console.WriteLine("You've made a deposit of $" + deposit);
        //}
    }
}
