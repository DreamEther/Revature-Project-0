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

        public void TakeOutLoan(double loanAmount, DateTime timeOfLoan)
        {
            DateOfTransaction = timeOfLoan;
            string loanString = loanAmount.ToString();
            LoanString = "-$" + loanString;
            LoanAmount = loanAmount;
            double doubleBalance = (double)Balance;
            double newBalance = doubleBalance - loanAmount;
            if (loanAmount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else if (loanAmount > 0 && loanAmount < 1000)
            {
                Console.WriteLine("Loans must be $1000 or greater...");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
        }
    }
}
