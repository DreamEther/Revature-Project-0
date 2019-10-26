using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class CD : Account
    {
        private static int businessAccountID = 3000;

        public DateTime Maturity { get; set; }
        public CD()
        {
            AccountType = "Certificate Deposit Account";
            AccountID = businessAccountID;
            InterestRate = (decimal)0.05;
            Balance = 0;
            businessAccountID++;
        }
        public override void MakeDeposit(decimal deposit, DateTime dateTime)
        {
            if (Balance > 0)
            {
                Console.WriteLine("Cannot make another deposit until term maturity is reached");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            if (deposit <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            if (deposit > 0 && deposit < 500)
            {
                Console.WriteLine("Term deposit must be $500 or greater...");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else
            {
                string depositString = deposit.ToString();
                DepositString = "+$" + depositString;
                DateOfTransaction = dateTime.AddYears(-1);
                DepositAmount = deposit;
                Balance += deposit;
                Balance += (Balance * InterestRate) * 12;
                var completeDeposit = new Transaction(Balance, DepositString, DepositAmount, DateOfTransaction);
                transactions.Add(completeDeposit);
                Console.WriteLine("At the end of 12 months, your balance after interest will be {0}", Balance);
                Console.WriteLine("You may withdraw your intial deposit and the interest accumulated on it at that time.");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
        }

        public override void MakeWithdrawal(decimal withdrawal, DateTime dateTime)
        {
            if (dateTime < DateOfTransaction.AddYears(1))
            {
                Console.WriteLine("Cannot make a withdrawal until end of term");
            }
            else if(withdrawal != DepositAmount)
            {
                Console.WriteLine("Must withdraw full amount from your Certificate Deposit");
            }
            else
            {
                string withdrawalString = withdrawal.ToString();
                WithdrawalString = "+$" + withdrawalString;
                WithdrawalAmount = withdrawal;
                Balance -= withdrawal;
                var completeWithdrawal = new Transaction(Balance, WithdrawalString, WithdrawalAmount, dateTime);
                transactions.Add(completeWithdrawal);
                Console.WriteLine("You have successfully withdrawn your completed Certificate Deposit! Thank you for choosing GenericBank!");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
        }
    }
}
