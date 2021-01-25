using System;
using System.Threading;

namespace Bomb
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите время таймера");
            object second = Password.EnterCorrectData<int>();

            var info = new Event(Message.ShowMessage, Result.FormatDisk);

            Thread inputPasswordThread = new Thread(Password.InputPassword);
            Thread timerThread = new Thread(new ParameterizedThreadStart(Timer.StartTimer));

            var password = new Password(timerThread);
            var timer = new Timer(inputPasswordThread);

            Console.WriteLine(Password.generatedPassword);
            Thread.Sleep(2000);

            timer.ShowTimeBeforTimerStarts();

            timerThread.Start(second);

            Console.ReadKey();
        }
    }
}
