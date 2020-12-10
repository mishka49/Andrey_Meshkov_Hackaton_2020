using System;
using System.Collections.Generic;

namespace Bank1
{
    public class Account
    {
        public Guid Id { get; }

        public List<Card> cards;

        public Account()
        {
            cards = new List<Card>();
            Id = Guid.NewGuid();
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Id: " + Id);

            foreach (var card in cards)
            {
                Console.WriteLine("Card: ");
                card.DisplayInfo();
            }
        }

        public void AddNewCard()
        {
            while (true)
            {
                Console.WriteLine("Введите тип карты");
                string type = Console.ReadLine();

                if (type == Convert.ToString(Type.Credit))
                {
                    cards.Add(new CreditCard());
                    break;
                }
                else if (type == Convert.ToString(Type.Debit))
                {
                    cards.Add(new DebitCard());
                    break;
                }
                else
                {
                    Console.WriteLine("введен неверный тип карты");
                    continue;
                }
            }
        }
    }
}
