using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace BankingApplication
{
    public class AccountManager
    {
        public static List<Customer> customers = new List<Customer>();

        private Account _account;
        private Customer _customer;
        private decimal _amount;
        public AccountManager()
        {
        }

        // Constructor takes in any account inheriting from Account and a customer instance retrieved from a unique pin
        //that account is then added to the customer's instance list of accounts.
        //Account instance foreign key reference CustomerID is then set equal to the current instance of customer's ID, which is Customer's primary key.
        public AccountManager(Account account, Customer customer)
        {
            _account = account; // set correct account type
            _customer = customer;
            _account.CustomerID = customer.ID;
            _customer.listOfAccounts.Add(_account);
        }

        public void ListOfAccountsByCustomerPin(int pin)
        {
            Customer customer = null;
            if (customers.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You must first register as a customer and open an account with us!");
                Thread.Sleep(3000);
                Program.ExecuteUserInput();
                
            }

            foreach (var cust in customers)
            {
                if (pin == cust.Pin)
                {
                    customer = cust;
                    break;
                }
            }
            Console.Clear();
            foreach (var account in customer.listOfAccounts)
            {               
                    Console.WriteLine("Account ID: {0}     Type: {1}     Account Balance: ${2}",
                    account.AccountID, account.AccountType, account.Balance);
            }
        }

        public void ListOfLoansByCustomerPin(int pin)
        {
            Customer customer = null;
            if (customers.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You must first register as a customer and open an account with us!");
                Thread.Sleep(2000);
                Program.ExecuteUserInput();
            }
            foreach (var cust in customers)
            {
                if (pin == cust.Pin)
                {
                    customer = cust;
                    if (customer.listOfAccounts.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You have no accounts open at the moment!");
                        Thread.Sleep(2000);
                        Program.ExecuteUserInput();
                    }
                    break;
                }
            }
            Console.Clear();
            
 
            foreach (var account in customer.listOfAccounts)
            {
                if (account.AccountType == "Loan")
                {
                    Console.WriteLine("Account ID: {0}     Type: {1}     Account Balance: ${2}",
                    account.AccountID, account.AccountType, account.Balance);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You do not have any loans to make a payment on...");
                    Thread.Sleep(2000);
                    Program.ExecuteUserInput();
                }
            }
        }

        public Customer GetCustomer(int pin)
        {
            Customer customer = null;
            foreach (var cust in AccountManager.customers)
            {
                if (pin == cust.Pin)
                {
                    customer = cust;
                    break;
                }
            }
            return customer;
        }

        public void CheckForNoAccounts(Customer customer)
        {
          if(customer.listOfAccounts.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("You have no open accounts!");
                Thread.Sleep(3000);
                Program.ExecuteUserInput();
            }
           
        }
        public void CloseAccount(Account account, Customer customer)
        {
            _customer = customer;
            _account = account;
            if (_account.Balance > 0)
            {
                Console.Clear();
                Console.WriteLine("Account must have a balance of $0 in order for you to close it.");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else
            {
                _customer.listOfAccounts.Remove(_account);
                Console.WriteLine($"Account {_account.AccountID} has been closed.");
                Console.Clear();
                Program.ExecuteUserInput();
            }          
        }

        public void Transfer(Account account1, Account account2, decimal withdrawalAmount)
        {
            _amount = withdrawalAmount;
            if (account1.AccountType == "Certificate Deposit" && account1.WithdrawalAmount != account1.Balance)
            {
                account1.MakeWithdrawal(_amount, DateTime.Now);
            }
            else if (account1.AccountType == "Loan")
            {
                Console.WriteLine("Cannot make a transfer from accounts of type loan!");
                UI.OnEnterPress();
                Program.ExecuteUserInput();
            }
            else
            {
                account1.MakeWithdrawal(_amount, DateTime.Now);
                account2.MakeDeposit(withdrawalAmount, DateTime.Now);
                Console.WriteLine("Transfer succeeded!");
            }

        }
    }
}
