using System;
using System.Threading;

namespace Bomb
{
    public class Password
    {
        public static int generatedPassword;

        private static Thread timerThread;

        public Password(Thread timerThread)
        {
            generatedPassword = CreatRandomPassword();
            Password.timerThread = timerThread;
        }

        public static void InputPassword()
        {
            while (timerThread.ThreadState != ThreadState.Stopped)
            {
                int pin = EnterPassword(Console.ReadLine());

                if (pin == generatedPassword)
                {
                    Event.InvokeEventNotify("Вы подобрали пароль");
                    Event.Notify -= Event.Message;
                    Event.End -= Event.Result;

                    break;
                }
            }
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

        public static int EnterPassword(string number)
        {
            int.TryParse(number, out int password);

            return password;
        }
    }
}
