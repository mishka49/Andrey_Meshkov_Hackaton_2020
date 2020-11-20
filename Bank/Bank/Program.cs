using System;
using System.Collections.Generic;

namespace Bank
{
    public class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Accounts> UserAccounts = new List<Accounts> { };

        public Users(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddNewAccount()
        {
            Accounts account = new Accounts();
            account.Number = CreatRandomNumberOfAccount();
            UserAccounts.Add(account);
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

                foreach (var card in UserAccounts)
                {

                    if (card.Number == ulong.Parse(number))
                    {
                        coincidence = true;
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
            Console.Clear();
            Console.WriteLine($"First name: {FirstName} \n List name: {LastName} \n");
            foreach (var account in UserAccounts)
            {
                Console.WriteLine("Account: ");
                Console.WriteLine("Type: " + account.Type);
                Console.WriteLine("Number: " + account.Number);
                Console.WriteLine("Balance: " + account.CalculateTotalBalance() + "\n");

                foreach (var card in account.UserCards)
                {
                    Console.WriteLine("Card: ");
                    Console.WriteLine("Type: " + card.Type);
                    Console.WriteLine("Number: " + card.Number);
                    Console.WriteLine("Balance: " + card.Balance + "\n");
                }

                foreach (var credit in account.UserCredits)
                {
                    Console.WriteLine("Credits: ");
                    Console.WriteLine("Status: " + credit.status);
                    Console.WriteLine("Total: " + credit.total);
                    Console.WriteLine("Period Of Time: " + credit.periodOfTime + "\n");
                }

            }
        }
    }


    public class Accounts : Cards
    {
        public new ulong Number { get; set; }
        public List<Cards> UserCards = new List<Cards> { };
        public List<Credits> UserCredits = new List<Credits> { };

        public double CalculateTotalBalance()
        {
            foreach (var card in UserCards)
            {
                Balance += card.Balance;
            }
            return Balance;
        }

        public void AddNewCards(string type="credit")
        {
            Cards card = new Cards();
            card.Type = type;
            card.Number = CreatRandomNumberOfCard();
            UserCards.Add(card);
        }

        public long CreatRandomNumberOfCard()
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

                foreach (var card in UserCards)
                {

                    if (card.Number == long.Parse(number))
                    {
                        coincidence = true;
                    }

                }

                if (!coincidence)
                {
                    return long.Parse(number);
                }

            }
        }
    }


    public class Cards
    {
        List<Credits> Credits = new List<Credits> { };
        public long Number { get; set; }
        public double Balance { get; set; } = 0.0;
        public string Type { get; set; }

        public string EnterCorrectType()
        {
            while (true)
            {
                string type = Console.ReadLine();

                if (type == "debit" || type == "credit")
                {
                    return type;
                }
                else
                {
                    Console.WriteLine("Выбран неверный тип");
                }

            }
        }
    }


    public class Menu
    {
        public double total;
        public double Total
        {
            get { return total; }

            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Введена неверная сумма");
                    Console.ReadKey();
                }
                else
                {
                    total = value;
                }
            }
        }

        public string firstName;
        public string lastName;
        public long number;
        public bool coincidence;
        public bool exception = false;
        public string type;
        public List<Users> People = new List<Users> { };

        public T EnterCorrectData<T>()
        {
            while (true)
            {

                try
                {
                    T result = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    return result;
                }
                catch
                {
                    Console.WriteLine("Неверный формат данных");
                }

            }
        }

        public bool CheckForRepetition(Users user)
        {
            foreach (var man in People)
            {

                if (man.FirstName == user.FirstName && man.LastName == user.LastName)
                {
                    return true;
                }

            }

            return false;
        }

        public void AddFundsToYourCard()
        {
            Console.Clear();
            coincidence = false;

            while (!coincidence)
            {

                Console.WriteLine("Введите имя пользователя");
                firstName = Console.ReadLine();
                lastName = Console.ReadLine();

                Console.WriteLine("Введите номер карты");
                number = EnterCorrectData<long>();
                Console.WriteLine("Введите сумму перевода");
                Total = EnterCorrectData<double>();

                foreach (var user in People)
                {

                    if (user.FirstName == firstName && user.LastName == lastName)
                    {
                        foreach (var account in user.UserAccounts)
                        {

                            foreach (var card in account.UserCards)
                            {

                                if (card.Number == number)
                                {
                                    coincidence = true;
                                    card.Balance += total;
                                    break;
                                }

                            }
                            break;

                        }
                        break;
                    }

                }

                if (!coincidence)
                {
                    Console.WriteLine("Совпадений не найдено");
                }

            }

            ShowMainMenu();
        }

        public void TransferMoneyFromCardToCard()
        {
            Console.Clear();
            coincidence = false;
            exception = true;

            while (exception && !coincidence)
            {
                Console.WriteLine("Введите свой номер карты");
                number = EnterCorrectData<long>();
                Console.WriteLine("Введите сумму перевода");
                total = EnterCorrectData<double>();

                foreach (var user in People)
                {
                    foreach (var account in user.UserAccounts)
                    {
                        foreach (var card in account.UserCards)
                        {

                            if (card.Number == number)
                            {
                                coincidence = true;

                                if (card.Type == "debit" && card.Balance < total)
                                {
                                    Console.WriteLine("На данной карте недостаточно средств \n Побробуйте другую карту");
                                    exception = true;
                                    break;
                                }
                                else if (card.Type == "credit" && card.Balance < 0)
                                {
                                    Console.WriteLine("На данной карте недостаточно средств \n Попробуйте другую карту");
                                    break;
                                }
                                else if (card.Type == "credit")
                                {

                                    foreach (var credit in account.UserCredits)
                                    {

                                        if (credit.status == "unpaid")
                                        {
                                            exception = true;
                                            Console.WriteLine("На данном счете есть непогашенный кредит");
                                            break;
                                        }

                                    }

                                }

                                if (!exception)
                                {
                                    exception = false;
                                    type = card.Type;
                                    card.Balance -= total;
                                    break;
                                }

                            }

                        }

                        break;
                    }

                    break;
                }


                if (!coincidence)
                {
                    Console.WriteLine("Совпадений не найдено");
                }
            }

            coincidence = false;
            while (!coincidence)
            {

                Console.WriteLine("Введите имя получателя");
                firstName = Console.ReadLine();
                lastName = Console.ReadLine();
                foreach (var user in People)
                {

                    if (user.FirstName == firstName && user.LastName == lastName)
                    {
                        Console.WriteLine("Введите номер карты получателя");
                        number = EnterCorrectData<long>();

                        foreach (var account in user.UserAccounts)
                        {

                            foreach (var card in account.UserCards)
                            {

                                if (card.Number == number)
                                {

                                    if (card.Type == "debit" && type == "credit")
                                    {
                                        Console.WriteLine("Нельзя совершать переводы с кредитовой карты на дебетовую");
                                    }
                                    else
                                    {
                                        card.Balance += total;
                                        coincidence = true;
                                        break;
                                    }

                                }

                            }

                        }
                    }

                }

                if (!coincidence)
                {
                    Console.WriteLine("Совпадений не найдено.");
                }

            }

            ShowMainMenu();
        }

        public void WithdrawMoneyFromTheCard()
        {
            Console.Clear();
            coincidence = false;

            while (!coincidence && exception)
            {
                Console.WriteLine("Введите имя пользователя");
                firstName = Console.ReadLine();
                lastName = Console.ReadLine();

                Console.WriteLine("Введите номер карты");
                number = EnterCorrectData<long>();

                Console.WriteLine("Введите сумму перевода");
                total = EnterCorrectData<double>();

                foreach (var user in People)
                {

                    if (user.FirstName == firstName && user.LastName == lastName)
                    {

                        foreach (var account in user.UserAccounts)
                        {

                            foreach (var card in account.UserCards)
                            {

                                if (card.Number == number)
                                {
                                    coincidence = true;


                                    if (card.Type == "debit" && card.Balance < total)
                                    {
                                        Console.WriteLine("На данной карте недостаточно средств \n Побробуйте другую карту");
                                        exception = true;
                                        break;
                                    }
                                    else if (card.Type == "credit" && card.Balance < 0)
                                    {
                                        exception = true;
                                        Console.WriteLine("На данной карте недостаточно средств \n Попробуйте другую карту");
                                        break;
                                    }
                                    else if (card.Type == "credit")
                                    {

                                        foreach (var credit in account.UserCredits)
                                        {

                                            if (credit.status == "unpaid")
                                            {
                                                exception = true;
                                                Console.WriteLine("На данном счете есть непогашенный кредит");
                                                break;
                                            }

                                        }

                                    }

                                    if (!exception)
                                    {
                                        exception = false;
                                        card.Balance -= total;
                                        break;
                                    }

                                }

                            }
                            break;

                        }
                        break;
                    }

                }

                if (!coincidence)
                {
                    Console.WriteLine("Совпадений не найдено");
                }

            }

            ShowMainMenu();
        }

        public void ObtainInformationAboutAccounts()
        {
            Console.Clear();
            coincidence = false;

            while (!coincidence)
            {

                Console.WriteLine("Введите имя пользователя");
                firstName = Console.ReadLine();
                lastName = Console.ReadLine();

                foreach (var user in People)
                {

                    if (user.FirstName == firstName && user.LastName == lastName)
                    {
                        coincidence = true;
                        user.DisplayInfo();
                        break;
                    }

                }

            }

            Console.ReadKey();
            ShowMainMenu();
        }

        public void AddUser()
        {
            Console.Clear();

            while (true)
            {

                Console.WriteLine("Введите имя пользователя");
                Users user = new Users(Console.ReadLine(), Console.ReadLine());

                if (CheckForRepetition(user))
                {
                    Console.WriteLine("Данный пользователь уже существет");
                    continue;
                }

                user.AddNewAccount();
                Console.WriteLine("Введите тип карты");
                user.UserAccounts[0].AddNewCards(user.UserAccounts[0].EnterCorrectType());

                People.Add(user);
                break;

            }

            ShowMainMenu();
        }

        public void OpenAccountOrAddCard()
        {
            Console.Clear();
            coincidence = false;

            while (!coincidence)
            {

                Console.WriteLine("Введите имя пользователя");
                firstName = Console.ReadLine();
                lastName = Console.ReadLine();
                coincidence = CheckForRepetition(new Users(firstName, lastName));

                if (!coincidence)
                {
                    Console.WriteLine("Совпадений не найдено");
                }

            }

            foreach (var user in People)
            {

                if (user.FirstName == firstName && user.LastName == lastName)
                {

                    while (true)
                    {
                        user.DisplayInfo();
                        Console.WriteLine("1.Открыть новый счет \n" + "2.Добавить карту");
                        string operation = Console.ReadLine();

                        switch (operation)
                        {
                            case "1":
                                user.AddNewAccount();
                                break;
                            case "2":
                                Console.WriteLine("Введите номер счета, к которому хотите привязать карту");
                                ulong number = EnterCorrectData<ulong>();
                                coincidence = false;

                                foreach (var account in user.UserAccounts)
                                {
                                    if (account.Number == number)
                                    {
                                        Console.WriteLine("Введите тип карты");
                                        account.AddNewCards(account.EnterCorrectType());
                                        coincidence = true;
                                    }
                                }

                                if (!coincidence)
                                {
                                    Console.WriteLine("Данного счета не существует");
                                    continue;
                                }
                                break;
                            default:
                                Console.WriteLine("Введен неверный номер операции");
                                continue;
                        }
                        break;
                    }

                }

            }

            ShowMainMenu();
        }

        public void ObtainCredit()
        {
            Credits credit = new Credits();
            Console.WriteLine("Введите сумму кредита");
            credit.total = EnterCorrectData<double>();
            Console.WriteLine("Введите на какой промежуток времени вы берете кредит");
            credit.periodOfTime = EnterCorrectData<int>();
            coincidence = false;
            exception = true;

            while (true)
            {
                Console.WriteLine("Введите номер счета к которому хотите привязать кредит");
                ulong number = EnterCorrectData<ulong>();

                foreach (var user in People)
                {

                    foreach (var account in user.UserAccounts)
                    {

                        if (account.Number == number)
                        {
                            foreach(var card in account.UserCards)
                            {

                                if(card.Type=="credit")
                                {
                                    exception = false;
                                }

                            }

                            if(!exception)
                            {      
                                account.AddNewCards();
                            }
                            coincidence = true;
                            credit.status = "unpaid";
                            account.UserCredits.Add(credit);
                        }

                    }

                }

                if(!coincidence)
                {
                    Console.WriteLine("Данного счета не существует");
                    continue;
                }
                break;
            }
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu: \n" +
                "1.Пополниить средства на карте \n" +
                "2.Перевести деньги с карты на карту\n" +
                "3.Снять деньги с карты \n" +
                "4.Получить информацию о счете \n" +
                "5.Добавить пользователя \n" +
                "6.Открыть счет или довабить карту \n" +
                "7.Получить кредит \n");

            while (true)
            {
                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "1":
                        AddFundsToYourCard();
                        break;
                    case "2":
                        TransferMoneyFromCardToCard();
                        break;
                    case "3":
                        WithdrawMoneyFromTheCard();
                        break;
                    case "4":
                        ObtainInformationAboutAccounts();
                        break;
                    case "5":
                        AddUser();
                        break;
                    case "6":
                        OpenAccountOrAddCard();
                        break;
                    case "7":
                        ObtainCredit();
                        break;
                    default:
                        Console.WriteLine("Данной операции не существует");
                        break;
                }
            }
        }

    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.ShowMainMenu();
            Console.ReadKey();
        }
    }

    public class Credits
    {
        public string status;
        public double total;
        public const double percent = 20;
        public double periodOfTime;
    }

}
