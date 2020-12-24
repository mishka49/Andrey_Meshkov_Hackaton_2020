using System;
using System.Threading;

namespace Bomb
{
    class Program
    {
        public static bool ContinueOrEndGame()
        {
            while (true)
            {
                Console.WriteLine("Желаете провторить? \n Yes or No");
                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "Yes":
                        return true;
                    case "No":
                        return false;
                    default:
                        Console.WriteLine("Введена неверная операция");
                        break;
                }
            }
        }

        public static int CreatRandomPassword()
        {
            Random random = new Random();
            string number = null;
            int numberOfIteration = 3;

            for (int i = 0; i < numberOfIteration; i++)
            {
                string digit = Convert.ToString(random.Next(0, 10));

                if (i == 0 && int.Parse(digit) == 0)
                {
                    numberOfIteration++;
                    continue;
                }

                number += digit;
            }

            return int.Parse(number);
        }

        static void Main(string[] args)
        {
            bool result = true;
            while (result)
            {
                Console.WriteLine("введите время таймера");
                object second = int.Parse(Console.ReadLine());

                int randomPassword = CreatRandomPassword();
                Console.WriteLine(randomPassword);

                Thread.Sleep(3000);

                StartTimer();

                Thread thread = new Thread(new ParameterizedThreadStart(Timer));
                thread.Start(second);

                while (thread.ThreadState != ThreadState.Stopped)
                {
                    int password = EnterPassword(Console.ReadLine());

                    if (password == randomPassword)
                    {
                        thread.Interrupt();
                        Console.WriteLine("Вы подобрали пароль");
                    }
                }

                result = ContinueOrEndGame();
            }

            Console.ReadKey();
        }

        public static void Timer(object second)
        {
            Console.WriteLine("Время пошло");
            Thread.Sleep(1000);

            Console.Clear();

            int posX = 0;
            int posY = 1;

            for (int i = 0; i < (int)second; i++)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Осталось: {(int)second - i} ");
                Console.SetCursorPosition(posX, posY);

                try
                {
                    Thread.Sleep(1000);
                }
                catch
                {
                    return;
                }

                posX = Console.CursorLeft;
                posY = Console.CursorTop;
            }

            Console.WriteLine("Таймер окончен. Вы проиграли");
        }

        public static void StartTimer()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();

                Console.WriteLine($"Начало через: {i + 1} ");
                Thread.Sleep(1000);
            }
        }

        public static int EnterPassword(string number)
        {
            int.TryParse(number, out int password);

            return password;
        }
    }
}
