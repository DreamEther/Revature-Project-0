using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Customer
    {

        static int numberOfCustomers = 0;

        public int _customerID;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pin { get; set; }

        public Customer(string firstName, string lastName, int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            Pin = pin;
            _customerID = Customer.numberOfCustomers; // setting first customer ID to 0
            Customer.numberOfCustomers++; // incrementing by 1 so that the next time we create a Customer object the ID will be 1 greater than the previous
        }

       

       

    }
}
