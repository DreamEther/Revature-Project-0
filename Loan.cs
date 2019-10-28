using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Loan : Account
    {
        private int interest = 5;
        private static int loanAccountID = 4000;
        public decimal LoanAmount { get; set; }
        public string LoanString { get; set; }

        public Loan()
        {
        }
        public Loan(int balance)
        {
            AccountType = "Loan";
            AccountID = loanAccountID;
            InterestRate = (decimal)0.05;
            Balance = balance;
            loanAccountID++;
        }

        public override void MakeWithdrawal(decimal loanAmount, DateTime timeOfLoan)
        {
            if (Balance > 0)
            {
                Console.WriteLine("Cannot make withdrawals on a loan. Please take out another loan or make a payment on an existing loan");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else
            {
                DateOfTransaction = timeOfLoan;
                LoanAmount = loanAmount;
                string loanString = LoanAmount.ToString();
                LoanString = "+$" + loanString;
                Balance += LoanAmount;
                Balance += (Balance * InterestRate);
                decimal roundedBalance = Decimal.Round(Balance, 2);
                Balance = roundedBalance;
                var completeLoan = new Transaction(Balance, LoanString, LoanAmount, DateOfTransaction);
                transactions.Add(completeLoan);
                Console.WriteLine("You've successfully taken out a loan!");
                Console.WriteLine("Interest rate of {0}% will be added to your loan", interest);
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
        }

        public void MakePayment(decimal payment, DateTime dateTime)
        {

            if (payment <= 0)
            {
                Console.WriteLine("Payment amount must be greater than zero");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else if (payment < Balance)
            {
                Console.WriteLine("The intended payment is more than your outstanding loan. Please enter an amount less than or equal to your outstanding loan");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else
            {
                string depositString = payment.ToString();
                DepositString = "+$" + depositString;
                DateOfTransaction = dateTime.AddYears(-1);
                DepositAmount = payment;
                Balance -= DepositAmount;
                decimal roundedBalance = Decimal.Round(Balance, 2);
                Balance = roundedBalance;
                var makePayment = new Transaction(Balance, DepositString, DepositAmount, DateOfTransaction);
                transactions.Add(makePayment);
                Console.WriteLine("Payment recieved!");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
        }
        public override void MakeDeposit(decimal payment, DateTime dateTime)
        {
            Console.WriteLine("Please select the 'Make a Payment' option to make a payment on your loan");
            UI.OnEnterPress();
            Program.ExecuteUserInput();
        }
    }
}
