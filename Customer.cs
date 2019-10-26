using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Customer
    {
       // public Dictionary<int, Account> listOfAccounts = new Dictionary<int, Account>();

        public List<Account> listOfAccounts = new List<Account>();
        public List<Loan> listOfLoans = new List<Loan>();
        static int numberOfCustomers = 0000;

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pin { get; set;}

        public Customer(string firstName, string lastName, int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            Pin = pin;
            ID = Customer.numberOfCustomers; // setting first customer ID to 0
            Customer.numberOfCustomers++; // incrementing by 1 so that the next time we create a Customer object the ID will be 1 greater than the previous
        }

       

       

    }
}
