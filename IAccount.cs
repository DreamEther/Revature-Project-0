using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public interface IAccount
    {     
        int AccountID { get; set; }
        double Balance { get; set; }

        public void MakeDeposit();

        public void MakeWithdrawal();

        public void MakeTermDeposit();

        //public void OpenAccount(Customer customer);
        
    }
}
