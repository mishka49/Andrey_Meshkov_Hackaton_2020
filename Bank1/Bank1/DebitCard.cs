using System;

namespace Bank1
{
    class DebitCard : Card
    {
        public DebitCard()
        {
            Type = Type.Debit;
        }

        public new void DisplayInfo()
        {
            Console.WriteLine("Type: " + Type);
        }
    }
}
