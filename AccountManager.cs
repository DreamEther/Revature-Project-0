using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankingApplication
{
    public class AccountManager
    {
        //private int _accountID;
        //private int _customerID;
        private Account _account;
        private Customer _customer;
        static int numberOfAccounts = 0;
        private string _accountType;
        private int _accountID;
        //private int _accountID;
        public AccountManager(Account account, Customer customer)
        {
            _account = account; // set correct account type
            //_customerID = customer.CustomerID;
            //_accountType = account.AccountType;
            _account.CustomerID = customer.ID;
            customer.listOfAccounts.Add(_account); //add account to the specific customers instance listOfAccounts
            _accountID = account.AccountID;// Give the first account made an ID of 0
            //AccountManager.numberOfAccounts++; //increment the static number by 1 so the next time this method is called, a new _accountID will be generated. 
            //_accountID = account.AccountID;
        }

        public AccountManager()
        {
        }

        public void ListOfAccountsByCustomerPin(int pin)
        {
            Customer customer = null;
            foreach (var cust in CustomerManager.customers)
            {
                if (pin == cust.Pin)
                {
                    customer = cust;
                    break;
                }
            }
            Console.Clear();
            foreach(var account in customer.listOfAccounts)
            {
               // _accountType = account.AccountType;
                Console.WriteLine("Account ID: {0}     Type: {1}     Account Balance: ${2}", 
                    account.AccountID, account.AccountType, account.Balance);
                Console.WriteLine("\nPlease press Enter to go back to the options menu...");
                WaitForKey(ConsoleKey.Enter);
                Console.Clear();
                break;
            }
            Program.ExecuteUserInput();
        }

        void WaitForKey(ConsoleKey key)
        {
            while (Console.ReadKey(true).Key != key)
            {
                
            }
        }


        public Customer GetCustomer(int pin)
        {
            Customer customer = null;
            foreach (var cust in CustomerManager.customers)
            {
                if (pin == cust.Pin)
                {
                    customer = cust;
                    break;
                }
            }
            return customer;
        }

        public void ListOfTransactionsPerAccount(Customer customer)
        {

        }


        //public void OpenAccount(Customer customer)
        //{

        //}
        //public void Initialize()
        //{
        //    _accountType.OpenAccount();
        ////}
    }
}
