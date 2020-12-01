using System;
using System.Collections.Generic;
using System.Text;

namespace Bank1
{
    class DebitCard:Card
    {
        //public string Type { get; }
        public DebitCard()
        {
            Type="Debit";
        }

        public new void DisplayInfo()
        {
            Console.WriteLine("Type: " + Type);
        }
    }
}
