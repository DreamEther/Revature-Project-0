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
            DisplayTransactions,
            CloseAccount
        };
        
        static void Main(string[] args)
        {
            ExecuteUserInput();
        }
        public static void ExecuteUserInput()
        {

            Console.WriteLine("Please select one of the following options: \n " +
               "1: Register as a customer\n 2: Create Checking Account\n 3: Create Business Account\n 4: Make a deposit\n" +
               " 5: Make a withdrawal\n 6: Make a transfer\n 7: Display a list of your accounts\n 8: Display a list of your transactions\n" +
               " 9: Close an account");
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
                    UI.RegistrationProcess();
                    break;
                }
                case UserAction.CreateChecking:
                {
                        UI.CreateCheckingAccount();
                        break;
                }
                case UserAction.Deposit:
                {
                        UI.Deposit();
                        break;
                }
                case UserAction.Withdrawal:
                    {
                        UI.Withdraw();
                        break;
                    }
                case UserAction.DisplayAccounts:
                    {
                        UI.DisplayAccountsByCustomer();
                        break;
                    }
                case UserAction.DisplayTransactions:
                    {
                        UI.ListTransactions();
                        break;
                    }
                case UserAction.CloseAccount:
                    {
                        UI.CloseAccount();
                        break;
                    }
            }           
        }
               
    }
}
