using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BankingApplication
{
    public class UI
    {
        private int userPin;
        public static void DisplayAccountsByCustomer()
        {
            Console.WriteLine("Please enter your unique user Pin:");
            string pin = Console.ReadLine();
            int pinNumber;
            while (pin.Length != 4 || !Int32.TryParse(pin, out pinNumber)) // need this condition to continuosly execute if user enters more than 4 numbers
            {
                Console.WriteLine("Incorrect Format: Please enter a unique user Pin that is 4 numbers long:");
                pin = Console.ReadLine();
            }
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
        }


        public static void StringOnlyCheck(string name)
        {
            while (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Incorrect Format: No numbers or special characters allowed in this field");
                name = Console.ReadLine();
            }
        }

        public static int CheckPin(string pin)
        {
            int pinNumber;
            while (pin.Length != 4 || !Int32.TryParse(pin, out pinNumber)) // need this condition to continuosly execute if user enters more than 4 numbers
            {
                Console.WriteLine("Incorrect Format: Please enter a unique user Pin that is 4 numbers long:");
                pin = Console.ReadLine();
           
            }
            return pinNumber;
        }

        public static int CheckAccountNumber(string accountNum)
        {
            int _accountNum;
            while (accountNum.Length != 4 || !Int32.TryParse(accountNum, out _accountNum)) // need this condition to continuosly execute if user enters more than 4 numbers
            {
                Console.WriteLine("Incorrect Format: Please enter a number that is no longer than 4 numbers");
                accountNum = Console.ReadLine();
            }
            return _accountNum;
        }
    }
}
