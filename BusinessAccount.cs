﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class BusinessAccount : Account
    {
        private static int businessAccountID = 2000;
        // public new string AccountType { get; set; } // if we do this we are overriding the property, and we would only want 
        // to do this if we would have specific conditions that we need to create for the getters and setters

        //public string AccountType { get; set; } // this would redefine the property we have in our base class, which we dont want to do. 
        //we simply want to set a value for it for this specific instance, which needs to be done inside a constructor. 
        public BusinessAccount()
        {
            AccountType = "Business";
            AccountID = businessAccountID;
            InterestRate = 5;
            Balance = 0;
            businessAccountID++;
        }
        public override void MakeWithdrawal(decimal withdrawal, DateTime dateTime)
        {
            string withdrawalString = withdrawal.ToString();
            WithdrawalString = "-$" + withdrawalString;
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
                
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else
            {
                Balance -= WithdrawalAmount;
            }
            var completeDeposit = new Transaction(Balance, WithdrawalString, DepositAmount, DateOfTransaction);
            transactions.Add(completeDeposit);
        }
    }
}
