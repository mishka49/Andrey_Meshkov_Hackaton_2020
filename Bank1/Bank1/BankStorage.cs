using System;
using System.Collections.Generic;

namespace Bank1
{
    public static class BankStorage
    {
        public static List<User> users;

        static BankStorage()
        {
            users = new List<User>();
        }

        public static void AddNewUser()
        {
            while (true)
            {
                bool coincidence = false;
                Console.WriteLine("Введите имя пользователя");
                string firstName = Console.ReadLine();
                string lastName = Console.ReadLine();

                foreach (var user in users)
                {
                    if (user.FirstName == firstName && user.LastName == lastName)
                    {
                        coincidence = true;
                        Console.WriteLine("Данный пользователь уже существует");
                        break;
                    }
                }

                if (!coincidence)
                {
                    users.Add(new User(firstName, lastName));
                    break;
                }
            }
        }
    }
}
