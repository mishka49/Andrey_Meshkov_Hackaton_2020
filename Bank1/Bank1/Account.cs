using System;
using System.Collections.Generic;

namespace Bank1
{
    class Account
    {
        public ulong Id { get; }
        public List<Card> cards;

        public Account()
        {
            cards = new List<Card> { };
            Id = CreatRandomNumberOfAccount();
        }

        public ulong CreatRandomNumberOfAccount()
        {
            string number = "";
            bool coincidence = false;
            Random random = new Random();
            string maxNumber = "18446744073709551615";
            int randomNumber;

            while (true)
            {
                for (int i = 0; i < 20; i++)
                {
                    randomNumber = random.Next(0, 10);

                    if (randomNumber <= int.Parse(Convert.ToString(maxNumber[i])))
                    {

                        if (i == 0 && randomNumber == 0)
                        {
                            i--;
                        }
                        else
                        {
                            number += Convert.ToString(randomNumber);
                        }

                    }
                    else
                    {
                        i--;
                    }

                }

                foreach (var user in BankStorage.users)
                {
                    foreach (var account in user.accounts)
                    {
                        if (account.Id == ulong.Parse(number))
                        {
                            coincidence = true;
                        }
                    }
                }

                if (!coincidence)
                {
                    return ulong.Parse(number);
                }
            }
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

                if (type == "Credit")
                {
                    cards.Add(new CreditCard());
                    break;
                }
                else if (type == "Debit")
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
