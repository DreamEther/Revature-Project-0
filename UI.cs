using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BankingApplication
{
    public class UI
    {
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
            CheckForCustomer();
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
            Customer customer = accountManager.GetCustomer(pinNumber);
            if (customer.listOfAccounts.Count == 0)
            {
                Console.WriteLine("You have no open accounts");
                OnEnterPress();
                Program.ExecuteUserInput();
            }
            Console.WriteLine("Please enter the AccountID for the account you wish to close: ");
            var answer = Console.ReadLine();
            int answerNum = CheckAccountNumber(answer);
            Account acc = customer.listOfAccounts.First(a => a.AccountID == answerNum);
            CheckAccountNumber(acc);
            accountManager.CloseAccount(acc, customer);
        }

        public static void CloseCDOnWithdrawal()
        {
            Console.WriteLine("You have successfully withdrawn your CD! Please enter your unique user Pin so we can close this account");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            Customer customer = accountManager.GetCustomer(pinNumber);
            Account acc = customer.listOfAccounts.FirstOrDefault(a => a.Balance == 0);
            customer.listOfAccounts.Remove(acc);
        }

        public static void Withdraw()
        {
            Console.WriteLine("Please enter your unique user Pin:");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
            Customer customer = accountManager.GetCustomer(pinNumber);
            accountManager.CheckForNoAccounts(customer);
            Console.WriteLine("Please type in the account ID for which you'd like to make a withdrawal");
            var answer = Console.ReadLine();
            int answerNum = CheckAccountNumber(answer);
            Account acc = customer.listOfAccounts.FirstOrDefault(a => a.AccountID == answerNum);
            CheckAccountNumber(acc);
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
            string firstNameSO = UI.StringOnlyCheck(firstName);
            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();
            string lastNameSO = UI.StringOnlyCheck(lastName);
            Console.WriteLine("Enter a unique user PIN(maximum of 4 numbers): ");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            Customer customer = new Customer(firstNameSO.ToLower(), lastNameSO.ToLower(), pinNumber);
            if (AccountManager.customers.Count != 0)
            {
                AccountManager.customers.Add(customer);
            }
            Console.Clear();
            string firstNameFixed = FirstCharToUpper(customer.FirstName);
            string lastNameFixed = FirstCharToUpper(customer.LastName);          
            Console.WriteLine("Is the following information correct? " +
                "Please enter 'Yes' or 'No' \n\nFull name: {0} {1}   Pin: {2}", firstNameFixed, lastNameFixed, customer.Pin);
            string answer = Console.ReadLine();
            AddCustomerToList(answer, customer);
            if (answer.Equals("No", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Please re-enter your registration details");
                    RegistrationProcess();
                }
            while ((!answer.Equals("Yes", StringComparison.InvariantCultureIgnoreCase)) || (!answer.Equals("No", StringComparison.InvariantCultureIgnoreCase)))
                {
                    Console.WriteLine("Please enter 'Yes' or 'No");
                    answer = Console.ReadLine();
                    AddCustomerToList(answer, customer);
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
            accountManager.CheckForNoAccounts(customer);
            Console.WriteLine("Please type in the account ID for which you'd like to make a deposit");
            var answer = Console.ReadLine();
            int accountNum = CheckAccountNumber(answer);            
            Account acc = customer.listOfAccounts.FirstOrDefault(a => a.AccountID == accountNum);
            CheckAccountNumber(acc);
            Console.Write("Please enter the amount you would like to deposit into Account: {0} \n$", acc.AccountID);
            var stringOutput = Console.ReadLine();
            decimal output;
            while (!Decimal.TryParse(stringOutput, out output))
            {
                Console.WriteLine("Incorrect Format: Please enter the amount you would like to deposit: $");
                stringOutput = Console.ReadLine();
            }
            acc.MakeDeposit(output, DateTime.Now);
            Program.ExecuteUserInput();
        }

        public static void TakeOutLoan()
        {
            Console.Clear();
            Console.WriteLine("You must sign in with your full name and pin before you can take out a loan");
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            UI.StringOnlyCheck(firstName);
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            UI.StringOnlyCheck(lastName);
            Console.WriteLine("Please enter your unique pin number");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            CheckForCustomer();
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
                Console.WriteLine("Please enter the amount you would like to request as a loan. Note: amount must be $1000 or greater.");
                Console.Write("$");
                string ans = Console.ReadLine();
                decimal output;
                while (!Decimal.TryParse(ans, out output)) // need this condition to continuosly execute if user enters more than 4 numbers
                {
                    Console.WriteLine("Please enter the amount you would like to request as a loan. Note: amount must be $1000 or greater.");
                    Console.Write("$");
                    ans = Console.ReadLine();
                }
                if (output < 1000)
                {
                    Console.WriteLine("Loans must be $1000 or more");
                    OnEnterPress();
                    Program.ExecuteUserInput();
                }
                var loan = new Loan(0);
                var takeOutLoan = new AccountManager(loan, customer);
                loan.MakeWithdrawal(output, DateTime.Now);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                Program.ExecuteUserInput();
            }
        }

        public static void MakeAPayment()
        {
            Console.WriteLine("Please enter your unique user Pin:");
            string pin = Console.ReadLine();
            int pinNumber = CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            Customer customer = accountManager.GetCustomer(pinNumber);
            accountManager.CheckForNoAccounts(customer);
            accountManager.ListOfLoansByCustomerPin(pinNumber);
            Console.WriteLine("Please type in the account ID for which you'd like to make a payment");
            var answer = Console.ReadLine();
            int accountNum = CheckAccountNumber(answer);
            Account acc = customer.listOfAccounts.FirstOrDefault(a => a.AccountID == accountNum);
            if (acc == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid account number!");
                Program.ExecuteUserInput();
            }
            Console.Write("Please enter you payment amount for AccountID: {0} \n$", acc.AccountID);
            var stringOutput = Console.ReadLine();
            decimal output;
            while (!Decimal.TryParse(stringOutput, out output))
            {
                Console.WriteLine("Incorrect Format: Please enter the amount you would like to pay: $");
                stringOutput = Console.ReadLine();
            }
            // need to type cast in order to be able to access MakePayments method...which isn't in the base class
            (acc as Loan).MakePayment(output, DateTime.Now); 
        }
        public static void MakeTransfer()
        {
            Console.WriteLine("Please enter your unique user Pin:");
            string pin = Console.ReadLine();
            int pinNumber = UI.CheckPin(pin);
            AccountManager accountManager = new AccountManager();
            accountManager.ListOfAccountsByCustomerPin(pinNumber);
            Customer customer = accountManager.GetCustomer(pinNumber);
            accountManager.CheckForNoAccounts(customer);
            Console.Write("Please type in the account ID from which you'd like to transfer from:");
            string transferFrom = Console.ReadLine();
            int transferFromAns = CheckAccountNumber(transferFrom);
            Account account1 = customer.listOfAccounts.First(a => a.AccountID == transferFromAns);
            CheckAccountNumber(account1);
            Console.WriteLine("Please enter the amount you would like to transfer");
            string withdrawString = Console.ReadLine();
            decimal withdrawalAmount = TryWithdraw(withdrawString);
            Console.WriteLine("Please enter the account ID you would like to transfer this amount to:");
            string tranferTo = Console.ReadLine();
            int transferToAns = CheckAccountNumber(tranferTo);
            Account account2 = customer.listOfAccounts.First(a => a.AccountID == transferToAns);
            CheckAccountNumber(account2);
            accountManager.Transfer(account1, account2, withdrawalAmount);
            Program.ExecuteUserInput();

        }


      /*
       * 
       * -----------------------------------------------Utility Functions----------------------------------------------------------------------
       * 
       */

        public static void WaitForKey(ConsoleKey key)
        {
            while (Console.ReadKey(true).Key != key)
            {

            }
        }
        public static string StringOnlyCheck(string name)
        {
            while (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Incorrect Format: No numbers or special characters allowed in this field");
                name = Console.ReadLine();
            }
            return name;
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

        public static void CheckPin(Customer customer)
        {
            foreach(var cust in AccountManager.customers)
            {
                if (AccountManager.customers.Count > 1)
                {
                    if (customer.Pin == cust.Pin)
                    {
                        Console.WriteLine("Sorry! Our records indicate that this pin has already been taken. Please try another combination");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Great! You have been registered as a customer of GenericBank!");
                        break;
                    }
                }
            }
            Program.ExecuteUserInput();


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

        public static void AddCustomerToList(string answer, Customer customer)
        {
            if (answer.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
            {
                if (AccountManager.customers.Count == 0)
                {
                    AccountManager.customers.Add(customer);
                    Console.WriteLine("Great! You have been registered as a customer of GenericBank!");
                    OnEnterPress();
                    Program.ExecuteUserInput();
                }
                else
                {
                    CheckPin(customer);
                    Console.WriteLine("Great! You have been registered as a customer of GenericBank!");
                    OnEnterPress();
                    Program.ExecuteUserInput();
                }

            }
        }

        public static void CheckAccountNumber(Account account)
        {
            if (account == null)
            {
                Console.Clear();
                Console.WriteLine("Invalid account number!");
                Program.ExecuteUserInput();
            }
        }

        public static void CheckForCustomer()
        {
            if (AccountManager.customers.Count == 0)
            {
                Console.WriteLine("Sorry, we couldn't find any customers related to the information provided!");
                Program.ExecuteUserInput();
            }
        }
    }
}
