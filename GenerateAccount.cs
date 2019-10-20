using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class GenerateAccount
    {
        private IAccount _accountType;
        private Customer _customer;
        public GenerateAccount(IAccount account)
        {
            _accountType = account;
        }

        public void OpenAccount(Customer customer)
        {
            _customer = customer;
            CustomerManager.customers.Add(customer);
        }
        //public void Initialize()
        //{
        //    _accountType.OpenAccount();
        ////}
    }
}
