using System;
using System.Collections.Generic;

namespace Bank1
{
    public class User
    {
        public List<Account> accounts;

        public string FirstName { get; }

        public string LastName { get; }

        public User(string firstName, string lastName)
        {
            accounts = new List<Account> { };
            FirstName = firstName;
            LastName = lastName;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"User name: {FirstName} {LastName}");

            foreach (var account in accounts)
            {
                Console.WriteLine("Account:");
                account.DisplayInfo();
            }
        }

        public void AddNewAccount()
        {
            accounts.Add(new Account());
        }
    }
}
