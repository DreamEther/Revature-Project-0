using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Loan
    {
        private static int loanAccountID = 4000;
        public double LoanAmount { get; set; }
        public decimal InterestRate { get; set; }

        public decimal Balance { get; set; }
        public int AccountID { get; set; }
        public string AccountType { get; set; }
        public int CustomerID { get; set; }
        public string LoanString{ get; set; }

        public DateTime DateOfTransaction { get; set; }

        public Loan()
        {
            AccountType = "Checking Account";
            AccountID = loanAccountID;
            InterestRate = (decimal)0.05;
            Balance = 0;
            loanAccountID++;
        }

        //include maybe 3 loan options of various amounts
        //public override void MakeWithdrawal(decimal withdrawal, DateTime dateTime)
        //{
        //    string withdrawalString = withdrawal.ToString();
        //    WithdrawalString = "-$" + withdrawalString;
        //    WithdrawalAmount = withdrawal;
        //    DateOfTransaction = dateTime;
        //    decimal newBalance = Balance - WithdrawalAmount;
        //    if (WithdrawalAmount <= 0)
        //    {
        //        Console.WriteLine("Withdrawal amount must be positive.");
        //        UI.OnEnterPress();
        //        Program.ExecuteUserInput();
        //    }
        //}

        public void TakeOutLoan(double loanAmount, DateTime timeOfLoan)
        {
            string loanString = loanAmount.ToString();
            LoanString = "-$" + loanString;
            LoanAmount = loanAmount;
            //DateOfTransaction = dateTime;
            //decimal newBalance = Balance - WithdrawalAmount;
            //if (WithdrawalAmount <= 0)
            //{
            //    Console.WriteLine("Withdrawal amount must be positive.");
            //    UI.OnEnterPress();
            //    Program.ExecuteUserInput();
            //}
        }
    }
}
