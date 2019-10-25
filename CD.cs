using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class CD
    {
        private Account CDTransaction;
        public int AccountID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime TermDepositStartDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void MakeTermDeposit(decimal deposit, DateTime dateTime)
        {
            if (Balance > 0)
            {
                Console.WriteLine("Cannot make another deposit until term maturity is reached");
            }
            if (deposit <= 0)
            {
                throw new System.ArgumentException("Deposit amount must be positive");
            }
            else if (deposit > 500)
            {
                Balance += deposit;
                var completeDeposit = new Transaction(deposit, dateTime);
                CDTransaction.transactions.Add(completeDeposit);
            }
            else
            {
                Console.WriteLine("Deposit must be $500 or greater");
            }
        }

        public void MakeTermWithdrawal(decimal withdrawal, DateTime dateTime)
        {
            if (withdrawal <= 0)
            {
                throw new System.ArgumentException("Withdrawal amount must be positive.");
            }
            else if (withdrawal > 0)
            {
                decimal newBalance = Balance - withdrawal;
                if (newBalance < 0)
                {
                    throw new System.ArgumentException("You do not have sufficient funds for this withdrawal.");
                }
            }
        }

    }
}
