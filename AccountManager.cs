using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BankingApplication
{
    public class AccountManager
    {
        public static List<Customer> customers = new List<Customer>();

        private Account _account;
        private Loan _loan;
        private Customer _customer;
        private decimal _amount;

        public AccountManager()
        {
        }

        public AccountManager(Account account, Customer customer)
        {
            _account = account; // set correct account type
            _customer = customer;
            _account.CustomerID = customer.ID;
            _customer.listOfAccounts.Add(_account); //add account to the specific customers instance listOfAccounts
        }

        public void ListOfAccountsByCustomerPin(int pin)
        {
            Customer customer = null;
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
                if (customer.listOfAccounts == null)
                {
                    Console.WriteLine("You have no open accounts! Please return to the main menu to apply for an account");
                    UI.OnEnterPress();
                    Program.ExecuteUserInput();
                }
                else
                {
                    Console.WriteLine("Account ID: {0}     Type: {1}     Account Balance: ${2}",
                    account.AccountID, account.AccountType, account.Balance);
                }

            }
        }

        public void ListOfLoansByCustomerPin(int pin)
        {
            Customer customer = null;
            foreach (var cust in customers)
            {
                if (pin == cust.Pin)
                {
                    customer = cust;
                    break;
                }
            }
            Console.Clear();
            //Account acc = customer.listOfAccounts.Where(a => a.AccountType == "Loan").ToList<Account>();
            foreach (var account in customer.listOfAccounts)
            {
                if (account.AccountType == "Loan")
                {
                    Console.WriteLine("Account ID: {0}     Type: {1}     Account Balance: ${2}",
                    account.AccountID, account.AccountType, account.Balance);
                }
                else
                {
                    return;
                }
            }
        }

        public void DisplayListOfTransactions(Account account)
        {
            _account = account;
            foreach (var transaction in _account.transactions)
            {
                Console.WriteLine($"{_account.AccountType} {_account.AccountID} {_account.Balance}");
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

        public void CloseAccount(Account account, Customer customer)
        {
            _customer = customer;
            _account = account;
            if (_account.Balance > 0)
            {
                Console.WriteLine("Account must have a balance of $0 in order for you to close it.");
                Console.Clear();
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

        public void CloseAccount(Account account)
        {
            Customer cust = null;
            _account = account;
            if (_account.Balance > 0)
            {
                Console.WriteLine("Account must have a balance of $0 in order for you to close it.");
            }
            cust.listOfAccounts.Remove(_account);
            Console.WriteLine($"Account {_account.AccountID} has been closed.");
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
