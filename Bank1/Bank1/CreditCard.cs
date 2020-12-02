using System;
using System.Collections.Generic;

namespace Bank1
{
    public class CreditCard : Card
    {
        public List<Credit> credits;

        public CreditCard()
        {
            Type = "Credit";
            credits = new List<Credit> { };
        }

        public new void DisplayInfo()
        {
            Console.WriteLine("Type: " + Type);
            base.DisplayInfo();
            Console.WriteLine("Credits: ");
            foreach (var credit in credits)
            {
                credit.DisplayInfo();
                Console.WriteLine();
            }
        }


    }
}
