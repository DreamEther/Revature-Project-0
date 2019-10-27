using System;
using System.Collections.Generic;
using System.Linq;
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
            int pinNumber = CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
            OnEnterPress();
            Program.ExecuteUserInput();
        }

        public static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
        
        public static void CreateCheckingAccount()
        {
            Console.Clear();
            Console.WriteLine("You must sign in with your full name and pin before creating an account.");
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            UI.StringOnlyCheck(firstName);
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            UI.StringOnlyCheck(lastName);
            Console.WriteLine("Please enter your unique pin number");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            if (AccountManager.customers.Count == 0)
            {
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                Program.ExecuteUserInput();
            }
            bool isFound = false;
            Customer customer = null;
            foreach (var cust in AccountManager.customers)
            {
                if (firstName.ToLower() == cust.FirstName && lastName.ToLower() == cust.LastName && pinNumber == cust.Pin)
                {
                    customer = cust;
                    isFound = true;
                    break;
                }
            }
            if (isFound == true)
            {
                var checkingAccount = new CheckingAccount();
                var generateAccount = new AccountManager(checkingAccount, customer);
                Console.WriteLine("You've successfully opened up a checking account with us!");
                OnEnterPress();
                Console.Clear();
                Program.ExecuteUserInput();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                Program.ExecuteUserInput();
            }
        }

        public static void CreateBusinessAccount()
        {
            Console.Clear();
            Console.WriteLine("You must sign in with your full name and pin before creating an account.");
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            UI.StringOnlyCheck(firstName);
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            UI.StringOnlyCheck(lastName);
            Console.WriteLine("Please enter your unique pin number");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            if (AccountManager.customers.Count == 0)
            {
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                Program.ExecuteUserInput();
            }
            bool isFound = false;
            Customer customer = null;
            foreach (var cust in AccountManager.customers)
            {
                if (firstName.ToLower() == cust.FirstName && lastName.ToLower() == cust.LastName && pinNumber == cust.Pin)
                {
                    customer = cust;
                    isFound = true;
                    break;
                }
            }
            if (isFound == true)
            {
                var businessAccount = new BusinessAccount();
                var generateAccount = new AccountManager(businessAccount, customer);
                Console.WriteLine("You've successfully opened up a business account with us!");
                OnEnterPress();
                Console.Clear();
                Program.ExecuteUserInput();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                Program.ExecuteUserInput();
            }
        }

        public static void CreateCDAccount()
        {
            Console.Clear();
            Console.WriteLine("You must sign in with your full name and pin before creating an account.");
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            UI.StringOnlyCheck(firstName);
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            UI.StringOnlyCheck(lastName);
            Console.WriteLine("Please enter your unique pin number");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            if (AccountManager.customers.Count == 0)
            {
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                Program.ExecuteUserInput();
            }
            bool isFound = false;
            Customer customer = null;
            foreach (var cust in AccountManager.customers)
            {
                if (firstName.ToLower() == cust.FirstName && lastName.ToLower() == cust.LastName && pinNumber == cust.Pin)
                {
                    customer = cust;
                    isFound = true;
                    break;
                }
            }
            if (isFound == true)
            {
                var cdAccount = new CD();
                var generateAccount = new AccountManager(cdAccount, customer);
                Console.WriteLine("You've successfully opened up a Certificate Deposit account with us!");
                OnEnterPress();
                Console.Clear();
                Program.ExecuteUserInput();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                Program.ExecuteUserInput();
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
            int answerNum = CheckAccountNumber(answer);
            Account acc = customer.listOfAccounts.First(a => a.AccountID == answerNum);
            Console.WriteLine($"{acc.AccountType}, Account ID:{acc.AccountID} Current Balance: ${acc.Balance}");
           // accountManager.DisplayListOfTransactions(acc);
            var listOfTransactionsInDes = acc.transactions.OrderByDescending(x => x.DateTime).ToList();
            foreach (var transaction in listOfTransactionsInDes)
            {
                Console.WriteLine($"{transaction.TransactionAsString} on {transaction.DateTime}  Balance: {transaction.newBalance}");
            }
        }

        public static void CloseAccount()
        {
            Console.WriteLine("Please enter your unique user Pin:");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
            Customer customer = accountManager.GetCustomer(pinNumber);
            Console.WriteLine("Please enter the AccountID for the account you wish to close: ");
            var answer = Console.ReadLine();
            int answerNum = CheckAccountNumber(answer);
            Account acc = customer.listOfAccounts.First(a => a.AccountID == answerNum);
            accountManager.CloseAccount(acc, customer);
            Program.ExecuteUserInput();
        }
        public static void Withdraw()
        {
            Console.WriteLine("Please enter your unique user Pin:");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
            Customer customer = accountManager.GetCustomer(pinNumber);
            Console.WriteLine("Please type in the account ID for which you'd like to make a withdrawal");
            var answer = Console.ReadLine();
            int answerNum = CheckAccountNumber(answer);         
            Account acc = customer.listOfAccounts.First(a => a.AccountID == answerNum);
            Console.Write("Please enter the amount you would like to withdraw from Account: {0} \n$", acc.AccountID);
            var stringOutput = Console.ReadLine();
            decimal output = TryWithdraw(stringOutput);   
            acc.MakeWithdrawal(output, DateTime.Now);
            Program.ExecuteUserInput();
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
            Customer customer = new Customer(firstName.ToLower(), lastName.ToLower(), pinNumber);
            string firstNameFixed = FirstCharToUpper(customer.FirstName);
            string lastNameFixed = FirstCharToUpper(customer.LastName);
            Console.WriteLine("Is the following information correct? " +
                "Please enter 'Yes' or 'No' \n\nFull name: {0} {1}   Pin: {2}", firstNameFixed, lastNameFixed, customer.Pin);
            string answer = Console.ReadLine();
            Console.Clear();
            AddCustomerToList(customer, answer);

        }
        public static void AddCustomerToList(Customer customer, string answer)
        {
            if (answer.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                AccountManager.customers.Add(customer);
                Console.WriteLine("Great! You have been registered as a customer of GenericBank!");
                OnEnterPress();
                Console.Clear();
                Program.ExecuteUserInput();
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

        public static void Deposit()
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
            Console.Write("Please enter the amount you would like to deposit into Account: {0} \n$", acc.AccountID);
            var stringOutput = Console.ReadLine();
            decimal output;
            while (!Decimal.TryParse(stringOutput, out output)) // need this condition to continuosly execute if user enters more than 4 numbers
            {
                Console.WriteLine("Incorrect Format: Please enter the amount you would like to deposit: $");
                stringOutput = Console.ReadLine();
            }
            acc.MakeDeposit(output, DateTime.Now);
            Program.ExecuteUserInput();
        }

        public static void MakeTransfer()
        {
            Console.WriteLine("Please enter your unique user Pin:");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
            Customer customer = accountManager.GetCustomer(pinNumber);
            Console.Write("Please type in the account ID from which you'd like to transfer from:");
            string transferFrom = Console.ReadLine();
            int transferFromAns = CheckAccountNumber(transferFrom);
            Account account1 = customer.listOfAccounts.First(a => a.AccountID == transferFromAns);
            Console.WriteLine("Please enter the amount you would like to transfer");
            string withdrawString = Console.ReadLine();
            decimal withdrawalAmount = TryWithdraw(withdrawString);
            Console.WriteLine("Please enter the account ID you would like to transfer this amount to:");
            string tranferTo = Console.ReadLine();
            int transferToAns = CheckAccountNumber(tranferTo);
            Account account2 = customer.listOfAccounts.First(a => a.AccountID == transferToAns);
            accountManager.Transfer(account1, account2, withdrawalAmount);
            Program.ExecuteUserInput();

        }
        public static void WaitForKey(ConsoleKey key)
        {
            while (Console.ReadKey(true).Key != key)
            {

            }
        }
        public static void StringOnlyCheck(string name)
        {
            while (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Incorrect Format: No numbers or special characters allowed in this field");
                name = Console.ReadLine();
            }
        }

        public static void OnEnterPress()
        {
            Console.WriteLine("\nPlease press Enter to go back to the options menu...");
            UI.WaitForKey(ConsoleKey.Enter);
            Console.Clear();
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

        public static decimal TryWithdraw(string amount)
        {
            decimal output;
            while (!Decimal.TryParse(amount, out output)) // need this condition to continuosly execute if user enters more than 4 numbers
            {
                Console.WriteLine("Incorrect Format: Please enter the amount you would like to withdraw: $");
                amount = Console.ReadLine();
            }
            return output;
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
