using System;

namespace Bank1
{
    public abstract class Card
    {
        public long Id { get; }

        public double Total { get; set; }

        public string Type { get; set; }

        public Card()
        {
            Id = CreatRandomIdOfCard();
            Total = 0;
        }

        public long CreatRandomIdOfCard()
        {
            string number = "";
            bool coincidence = false;
            Random random = new Random();

            while (true)
            {

                for (int i = 0; i < 16; i++)
                {
                    int randomNumber = random.Next(0, 10);

                    if (i == 0 && randomNumber == 0)
                    {
                        i--;
                    }
                    else
                    {
                        number += Convert.ToString(randomNumber);
                    }

                }

                foreach (var user in BankStorage.users)
                {

                    foreach (var account in user.accounts)
                    {

                        foreach (var card in account.cards)
                        {

                            if (card.Id == long.Parse(number))
                            {
                                coincidence = true;
                                break;
                            }

                        }

                    }

                }

                if (!coincidence)
                {
                    return long.Parse(number);
                }

            }

        }

        public void DisplayInfo()
        {
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Total: " + Total);
        }
    }
}
