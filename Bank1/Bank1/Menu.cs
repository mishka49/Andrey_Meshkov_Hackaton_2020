using System;

namespace Bank1
{
    public class Menu
    {
        private static bool coincidence;

        public Menu()
        {
            ShowMainMenu();
        }
        static T EnterCorrectData<T>()
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

        static void ShowMainMenu()
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

        static void AddFundsToYourCard()
        {
            Console.Clear();
            coincidence = false;

            while (!coincidence)
            {

                Console.WriteLine("Введите имя пользователя");
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();

                Console.WriteLine("Введите номер карты");
                long id = EnterCorrectData<long>();

                Console.WriteLine("Введите сумму перевода");
                double total = EnterCorrectData<double>();

                foreach (var user in BankStorage.users)
                {

                    if (user.FirstName == firstName && user.LastName == lastName)
                    {
                        foreach (var account in user.accounts)
                        {

                            foreach (var card in account.cards)
                            {

                                if (card.Id == id)
                                {
                                    coincidence = true;
                                    card.Total += total;
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

        static void TransferMoneyFromCardToCard()
        {
            Console.Clear();

            coincidence = false;
            long yourId;
            double total = 0;
            string yourType = "Debit";

            while (!coincidence)
            {
                Console.WriteLine("Введите свой номер карты");
                yourId = EnterCorrectData<long>();

                Console.WriteLine("Введите сумму перевода");
                total = EnterCorrectData<double>();

                try
                {
                    foreach (var user in BankStorage.users)
                    {

                        foreach (var account in user.accounts)
                        {

                            foreach (var card in account.cards)
                            {

                                if (card.Id == yourId)
                                {
                                    coincidence = true;

                                    if (card is DebitCard && card.Total < total)
                                    {
                                        throw new Exception("Недостаточно средств на карте");
                                    }
                                    else if (card is CreditCard && card.Total < 0)
                                    {
                                        throw new Exception("Недостаточно средств на карте");
                                    }
                                    else if (card is CreditCard)
                                    {
                                        yourType = "Credit";
                                        foreach (var credit in (card as CreditCard).credits)
                                        {
                                            if (credit.Status == "norepaid")
                                            {
                                                throw new Exception("На данной карте есть непогашенный кредит");
                                            }
                                        }

                                    }
                                    else
                                    {
                                        card.Total -= total;
                                    }

                                    break;
                                }

                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            coincidence = false;

            while (!coincidence)
            {
                Console.WriteLine("Введите имя получателя");
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();

                Console.WriteLine("Введите номер карты получателя");
                long idOfRepicient = EnterCorrectData<long>();

                try
                {
                    foreach (var user in BankStorage.users)
                    {

                        if (user.FirstName == firstName && user.LastName == lastName)
                        {
                            foreach (var account in user.accounts)
                            {
                                foreach (var card in account.cards)
                                {

                                    if (card.Id == idOfRepicient)
                                    {

                                        coincidence = true;
                                        if (card.Type == "Debit" && yourType == "Credit")
                                        {
                                            throw new Exception("Нельзя осуществлять переводы с кредитовой карты на дебитовую");
                                        }
                                        else
                                        {
                                            card.Total += total;
                                        }

                                    }

                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

            }
        }


        static void WithdrawMoneyFromTheCard()
        {
            Console.Clear();
            coincidence = false;

            while (!coincidence)
            {

                Console.WriteLine("Введите имя пользователя");
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();

                Console.WriteLine("Введите номер карты");
                long id = EnterCorrectData<long>();

                Console.WriteLine("Введите сумму перевода");
                double total = EnterCorrectData<double>();

                foreach (var user in BankStorage.users)
                {

                    if (user.FirstName == firstName && user.LastName == lastName)
                    {
                        foreach (var account in user.accounts)
                        {

                            foreach (var card in account.cards)
                            {

                                if (card.Id == id)
                                {
                                    coincidence = true;
                                    card.Total -= total;
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


        static void ObtainInformationAboutAccounts()
        {
            Console.Clear();

            Console.WriteLine("Введите имя пользователя");
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();

            foreach (var user in BankStorage.users)
            {
                if (user.FirstName == firstName && user.LastName == lastName)
                {
                    user.DisplayInfo();
                    break;
                }
            }

            Console.ReadKey();
            ShowMainMenu();
        }

        static void AddUser()
        {
            Console.Clear();

            BankStorage.AddNewUser();
            BankStorage.users[BankStorage.users.Count - 1].AddNewAccount();
            BankStorage.users[BankStorage.users.Count - 1].accounts[BankStorage.users[BankStorage.users.Count - 1].accounts.Count - 1].AddNewCard();

            ShowMainMenu();
        }

        static void OpenAccountOrAddCard()
        {
            Console.Clear();
            coincidence = false;

            while (!coincidence)
            {

                Console.WriteLine("Введите имя пользователя");
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();

                foreach (var user in BankStorage.users)
                {
                    if (user.FirstName == firstName && user.LastName == lastName)
                    {
                        coincidence = true;

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
                                    ulong Id = EnterCorrectData<ulong>();
                                    coincidence = false;

                                    foreach (var account in user.accounts)
                                    {
                                        if (account.Id == Id)
                                        {
                                            account.AddNewCard();
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

        static void ObtainCredit()
        {
            Console.Clear();

            Console.WriteLine("Введите сумму кредита");
            double total = EnterCorrectData<double>();
            Console.WriteLine("Введите на какой промежуток времени вы берете кредит");
            double periodOfTime = EnterCorrectData<int>();
            coincidence = false;

            while (!coincidence)
            {
                Console.WriteLine("Введите номер карты к которой хотите привязать кредит");
                long id = EnterCorrectData<long>();

                foreach (var user in BankStorage.users)
                {

                    foreach (var account in user.accounts)
                    {

                        foreach (var card in account.cards)
                        {
                            if (card.Id == id && card.Type == "Credit")
                            {
                                (card as CreditCard).credits.Add(new Credit(total, periodOfTime));
                                card.Total += total;
                                coincidence = true;
                            }

                        }

                    }

                }

                if (!coincidence)
                {
                    Console.WriteLine("Данной карты не существует или невозможно привязать к ней кредит");
                }
            }

            ShowMainMenu();
        }
    }

}

