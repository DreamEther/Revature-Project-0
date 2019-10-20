using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public interface IAccount
    {     
        int AccountID { get; set; }
        double Balance { get; set; }

        
        DateTime TermDepositStartDate { get; set; }

        public void MakeDeposit(double deposit, DateTime dateTime);

        public void MakeWithdrawal(double withdrawal, DateTime dateTime);

        public void MakeTermDeposit(double deposit, DateTime dateTime);

        public void MakeTermWithdrawal(double withdrawal, DateTime dateTime);

        //public void OpenAccount(Customer customer);
        
    }
}
