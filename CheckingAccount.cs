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
            InterestRate = (decimal)0.05;
            Balance = 0;
            checkingAccountID++;
        }
        public override void MakeWithdrawal(decimal withdrawal, DateTime dateTime)
        {
            string withdrawalString= withdrawal.ToString();
            WithdrawalString= "-$" + withdrawalString;
            WithdrawalAmount = withdrawal;
            DateOfTransaction = dateTime;
            decimal newBalance = Balance - WithdrawalAmount;
            if (WithdrawalAmount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else if (WithdrawalAmount > 0 && newBalance < 0)
            {
                    Console.WriteLine("You do not have sufficient funds for this withdrawal.");
                    UI.OnEnterPress();
                    Program.ExecuteUserInput();
            }
            else
            {
                Balance -= WithdrawalAmount;
                var completeDeposit = new Transaction(Balance, WithdrawalString, DepositAmount, DateOfTransaction);
                transactions.Add(completeDeposit);
            }
            
        }
    }
}
