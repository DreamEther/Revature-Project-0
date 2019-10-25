using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class CheckingAccount : Account
    {
        private static int checkingAccountID = 1000;
        //public Customer CustomerID { get; set; }

        public CheckingAccount()
        {
            AccountType = "Checking Account";
            AccountID = checkingAccountID;
            InterestRate = 5;
            Balance = 0;
            checkingAccountID++;
        }
        public override void MakeDeposit(decimal deposit, DateTime dateTime)
        {
            DepositAmount = deposit;
            DateOfTransaction = dateTime;
            Balance += deposit;
            var completeDeposit = new Transaction(DepositAmount, DateOfTransaction);
            transactions.Add(completeDeposit);
        }

        public override void MakeWithdrawal(decimal withdrawal, DateTime dateTime)
        {

            WithdrawalAmount = withdrawal;
            DateOfTransaction = dateTime;
            Balance -= withdrawal;
            if(Balance <= 0)
            {
                Balance *= InterestRate;
                Console.WriteLine("You've overdrafted your account. Interest  of 5% will be calculated accordingly...");
                Console.WriteLine("Press Enter to see ");

            }
            var completeDeposit = new Transaction(DepositAmount, DateOfTransaction);
            transactions.Add(completeDeposit);
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
