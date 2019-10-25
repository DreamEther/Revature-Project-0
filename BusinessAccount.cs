using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    public class BusinessAccount : Account
    {
        private Account accountType;
        public int Loan { get; set; }

        //   public new string AccountType { get; set; } // if we do this we are overriding the property, and we would only want 
        // to do this if we would have specific conditions that we need to create for the getters and setters
        //   public string AccountType { get; set; } // this would redefine the property we have in our base class, which we dont want to do. 
        //we simply want to set a value for it for this specific instance
        // which needs to be done inside a constructor. 
        public BusinessAccount()
        {
            accountType.AccountType = "Bus"; // is this the same as setting a value for the Property below?
            AccountType = "Busin";
        }

        public override void MakeDeposit(decimal deposit, DateTime dateTime)
        {
            Console.WriteLine("Placeholder");
            
        }

        public override void MakeWithdrawal(decimal withdrawal, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
