using System;
using System.Collections.Generic;

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
            //ExecuteUserInput();
            Customer cust = new Customer("jake", "hills", 5212);
            Customer cust1 = new Customer("blake", "rills", 5212);
            var checkingAccount = new CheckingAccount()
            {
                AccountID = 000,
                InterestRate = 5.0,
                Balance = 0.00
            };
            var generateAccount = new GenerateAccount(checkingAccount);
            generateAccount.OpenAccount(cust);
            generateAccount.OpenAccount(cust1);
            foreach(var customer in CustomerManager.customers)
            {
                Console.WriteLine(customer._customerID);
            }
            //CheckingAccount checkingAccount = new CheckingAccount();
            //checkingAccount.Deposit(100.34);
            //string message = String.Format()
        }

        public static void ExecuteUserInput()
        {

            Console.WriteLine("Please select one of the following options: \n " +
               "1: Register as a customer\n 2: Create Checking Account\n 3: Create Business Account\n 4: Make a deposit\n" +
               "5: Make a withdrawal\n 6: Make a transfer\n 7: Display a list of your accounts\n 8: Display a list of your transactions");
            string userInput = Console.ReadLine();
            UserAction userAction = (UserAction)Convert.ToInt32(userInput);

            switch (userAction)
            {
                case UserAction.Register:
                {
                    RegistrationProcess();
                    break;
                }
                case UserAction.DisplayTransactions:
                {

                        break;
                }
            }           
        }
        public static void RegistrationProcess()
        {
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter a unique user PIN(maximum of 4 numbers): ");
            string pin = Console.ReadLine();
            int pinNumber;
            while (pin.Length > 4) // need this condition to continuosly execute if user enters more than 4 numbers
            {
                Console.WriteLine("Pin cannot be more than four numbers long: Please enter a unique user Pin: ");
                pin = Console.ReadLine();
            } 
            // there's an issue when we first enter a string...nothing happens. only works every second try. 
            while  (!Int32.TryParse(Console.ReadLine(), out pinNumber))
            {
                Console.WriteLine("Incorrect Format: Please enter a unique user Pin:");
                pin = Console.ReadLine();
            }




            Customer customer = new Customer(firstName, lastName, pinNumber);
            CustomerManager.customers.Add(customer);
            Console.WriteLine("Is the following information correct? + " +
                "Please enter 'Yes' or 'No' {0}, {1}, {2}", customer.FirstName, customer.LastName, customer.Pin);
            string answer = Console.ReadLine();
            if (answer.Equals("No", StringComparison.InvariantCultureIgnoreCase) || answer.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Great! You have been registered as a customer of GenericBank!");
                Console.WriteLine(CustomerManager.customers.Count);
                ExecuteUserInput();
            }
            RegistrationProcess();
        }

    }
}
