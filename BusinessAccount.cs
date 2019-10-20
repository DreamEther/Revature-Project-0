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

        //public void OpenAccount(Customer customer)
        //{
            
        //}
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

        
        
    }
}
