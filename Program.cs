using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankingApplication
{
    class Program
    {
        enum UserAction
        {
            Register = 1,
            CreateChecking,
            CreateBusiness,
            Deposit,
            Withdrawal,
            Transfer,
            DisplayAccounts,
            DisplayTransactions
        };
        
        static void Main(string[] args)
        {
            ExecuteUserInput();
            Customer cust = new Customer("jake", "hills", 5212);
            Customer cust1 = new Customer("blake", "rills", 5212);

            
            //var checkingAccount = new CheckingAccount()
            //{
            //    AccountID = 000,
            //    InterestRate = 5.0,
            //    Balance = 0.00
            //};
            //var generateAccount = new GenerateAccount(checkingAccount);
            //generateAccount.OpenAccount(cust);
            //generateAccount.OpenAccount(cust1);
            //foreach(var customer in CustomerManager.customers)
            //{
            //    Console.WriteLine(customer._customerID);
            //}
            //CheckingAccount checkingAccount = new CheckingAccount();
            //checkingAccount.Deposit(100.34);
            //string message = String.Format()
        }
        public static void ExecuteUserInput()
        {

            Console.WriteLine("Please select one of the following options: \n " +
               "1: Register as a customer\n 2: Create Checking Account\n 3: Create Business Account\n 4: Make a deposit\n" +
               " 5: Make a withdrawal\n 6: Make a transfer\n 7: Display a list of your accounts\n 8: Display a list of your transactions");
            string userInput = Console.ReadLine();
            int answer1;
            while(!int.TryParse(userInput, out answer1))
            {
                Console.WriteLine("Please enter the number associated with the task you are trying to complete.");
                userInput = Console.ReadLine();
            }
            UserAction userAction = (UserAction)Convert.ToInt32(userInput);

            switch (userAction)
            {
                case UserAction.Register:
                {
                    Console.Clear();
                    RegistrationProcess();
                    break;
                }
                case UserAction.CreateChecking:
                {
                        CreateCheckingAccount();
                        break;
                }
                case UserAction.Deposit:
                {
                        Console.WriteLine("Please enter your unique user Pin:");
                        string pin = Console.ReadLine();
                        int pinNumber = UI.CheckPin(pin);
                        AccountManager accountManager = new AccountManager();
                        accountManager.ListOfAccountsByCustomerPin(pinNumber);
                        Customer customer = accountManager.GetCustomer(pinNumber);
                        Console.WriteLine("Please type in the account ID for which you'd like to make a deposit");
                        var answer = Console.ReadLine();
                        int answerNum;
                        while (answer.Length != 4 || !Int32.TryParse(answer, out answerNum)) // need this condition to continuosly execute if user enters more than 4 numbers
                        {
                            Console.WriteLine("Incorrect Format: Please enter a number that is no longer than 4 numbers");
                            answer = Console.ReadLine();
                        }
                        Account acc = customer.listOfAccounts.First(a => a.AccountID == answerNum);
                        Console.WriteLine("Please enter the amount you would like to deposit into Account: {0} $", acc.AccountID);
                        var stringOutput = Console.ReadLine();
                        decimal output;
                        while (!Decimal.TryParse(stringOutput, out output)) // need this condition to continuosly execute if user enters more than 4 numbers
                        {
                            Console.WriteLine("Incorrect Format: Please enter the amount you would like to deposit: $");
                            stringOutput = Console.ReadLine();
                        }
                        acc.MakeDeposit(output, DateTime.Now);
                        ExecuteUserInput();
                        break;
                }
                case UserAction.DisplayAccounts:
                    {
                        UI.DisplayAccountsByCustomer();
                        break;
                    }
                case UserAction.DisplayTransactions:
                    {
                        ListTransactions();
                        break;
                    }
            }           
        }
       
        public static void RegistrationProcess()
        {        
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            UI.StringOnlyCheck(firstName);
            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();
            UI.StringOnlyCheck(lastName);
            Console.WriteLine("Enter a unique user PIN(maximum of 4 numbers): ");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            Console.Clear();
            Customer customer = new Customer(firstName, lastName, pinNumber);
            Console.WriteLine("Is the following information correct? " +
                "Please enter 'Yes' or 'No' \n\nFull name: {0} {1}   Pin: {2}", customer.FirstName, customer.LastName, customer.Pin);
            string answer = Console.ReadLine();
            AddCustomerToList(customer, answer);
            
        }
        
        public static void CreateCheckingAccount()
        {
            Console.WriteLine(CustomerManager.customers.Count);
            Console.WriteLine("You must sign in with your full name and pin before creating an account:");
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            UI.StringOnlyCheck(firstName);
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            UI.StringOnlyCheck(lastName);
            Console.WriteLine("Please enter your unique pin number");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            if (CustomerManager.customers.Count == 0)
            {
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                ExecuteUserInput();
            }
            bool isFound = false;
            foreach (var cust in CustomerManager.customers)
            {    
                if (firstName == cust.FirstName && lastName == cust.LastName && pinNumber == cust.Pin)
                {
                    isFound = true;
                }
                if (isFound == true)
                {
                    var checkingAccount = new CheckingAccount();
                    var generateAccount = new AccountManager(checkingAccount, cust);
                    Console.WriteLine("You've successfully opened up a checking account with us!");
                    ExecuteUserInput();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                    ExecuteUserInput();
                }
            }
           
                
            
        }

        public static void ListTransactions()
        {
            Console.WriteLine("Please enter your unique user Pin:");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
            Customer customer = accountManager.GetCustomer(pinNumber);
            Console.WriteLine("To see a list of all transactions for an account, please enter the appropriate AccountID:");
            var answer = Console.ReadLine();
            int answerNum = UI.CheckAccountNumber(answer);
            Account acc = customer.listOfAccounts.First(a => a.AccountID == answerNum);
            Console.WriteLine($"{acc.AccountType} - {acc.AccountID}: Current Balance: ${acc.Balance}");
            var listOfTransactionsInDes = acc.transactions.OrderByDescending(x => x.DateTime).ToList();
            foreach (var transaction in listOfTransactionsInDes)
            {
                Console.WriteLine($"Deposit of: ${transaction.TransactionAmount} on {transaction.DateTime}");
            }
        }
        public static void AddCustomerToList(Customer customer, string answer)
        {
            if (answer.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                CustomerManager.customers.Add(customer);
                Console.WriteLine("Great! You have been registered as a customer of GenericBank!");
                //Console.WriteLine(CustomerManager.customers.Count);
                ExecuteUserInput();
            }
            else if (answer.Equals("No", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Please re-enter your registration details");
                RegistrationProcess();
            }
            while (!answer.Equals("Yes", StringComparison.InvariantCultureIgnoreCase) || (!answer.Equals("No", StringComparison.InvariantCultureIgnoreCase)))
            {
                Console.WriteLine("Please write 'Yes' or 'No'.");
                break;
            }

        }
       

    }
}
