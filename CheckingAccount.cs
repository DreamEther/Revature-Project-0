using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class CheckingAccount : IAccount
    {
        public double InterestRate { get; set; }
        
        public int AccountID { get; set; }
        public double Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void MakeDeposit()
        {
            throw new NotImplementedException();
        }

        public void MakeTermDeposit()
        {
            throw new NotImplementedException();
        }

        public void MakeWithdrawal()
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
