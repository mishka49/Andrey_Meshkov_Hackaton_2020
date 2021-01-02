using System;
using System.Threading;

namespace Bomb
{
    class Program
    {
        public static int EnterPassword(string number)
        {
            int.TryParse(number, out int password);

            return password;
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

        public static T EnterCorrectData<T>()
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

        public static Thread timerThread;

        private static object password;

        public delegate void Message(string message);

        public static event Message Notify;

        public static event Message Info;

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public delegate void Result();

        public static event Result End;

        public static void FormatDisk()
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");
        }


        public static void Main(string[] args)
        {
            Notify += ShowMessage;
            Info += ShowMessage;

            Console.WriteLine("Введите время таймера");
            object second = EnterCorrectData<int>();

            password = CreatRandomPassword();
            Console.WriteLine(password);

            Thread.Sleep(2000);

            StartTimer();

            timerThread = new Thread(new ParameterizedThreadStart(Timer));
            timerThread.Start(second);

            timerThread.Join();

            Console.ReadKey();
        }
        public static void StartTimer()
        {
            End += FormatDisk;
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();

                Info?.Invoke($"Начало через: {3 - i} ");
                Thread.Sleep(1000);
            }
        }

        public static void InputPassword(object password)
        {
            while (timerThread.ThreadState != ThreadState.Stopped)
            {
                int pin = EnterPassword(Console.ReadLine());

                if (pin == (int)password)
                {
                    Notify?.Invoke("Вы подобрали пароль");
                    Notify -= ShowMessage;
                    End -= FormatDisk;

                    break;
                }
            }
        }

        public static void Timer(object second)
        {
            Thread inputPasswordThread = new Thread(new ParameterizedThreadStart(InputPassword));
            inputPasswordThread.Start(password);

            Info?.Invoke("Время пошло");
            Thread.Sleep(1000);

            Console.Clear();

            int posX = 0;
            int posY = 1;

            for (int i = 0; i < (int)second; i++)
            {
                Console.SetCursorPosition(0, 0);
                Info?.Invoke($"Форматирование диска начнется через: {(int)second - i} ");
                Console.SetCursorPosition(posX, posY);

                if (inputPasswordThread.ThreadState != ThreadState.Stopped)
                {
                    Thread.Sleep(1000);
                }
                else
                {
                    break;
                }

                posX = Console.CursorLeft;
                posY = Console.CursorTop;
            }

            Notify?.Invoke("Таймер окончен.");
            End?.Invoke();
        }
    }
}
