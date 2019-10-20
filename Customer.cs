using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pin { get; set; }

        private int _customerID = 000;

        public Customer(string firstName, string lastName, int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            Pin = Pin;
        }

    }
}
