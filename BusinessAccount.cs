using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class BusinessAccount : IAccount
    {
        public int Loan { get; set; }
        public int AccountID { get; set; }
        public double Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime TermDepositStartDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public void OpenAccount(Customer customer)
        //{

        //}

        public void MakeDeposit(double deposit, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void MakeTermDeposit(double deposit, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void MakeTermWithdrawal(double withdrawal, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void MakeWithdrawal(double withdrawal, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
