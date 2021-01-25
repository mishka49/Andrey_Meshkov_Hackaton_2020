using System;
using System.Threading;


namespace Bomb
{
    public class Timer
    {
        private  static Thread inputPasswordThread;

        public Timer(Thread inputPasswordThread)
        {
            Timer.inputPasswordThread = inputPasswordThread;
        }

        public void ShowTimeBeforTimerStarts()
        {
            
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();

                Event.InvokeEventInfo($"Начало через: {3 - i} ");
                Thread.Sleep(1000);
            }
        }

        public static void StartTimer(object second)
        {
            inputPasswordThread.Start();

            Event.InvokeEventInfo("Время пошло");
            Thread.Sleep(1000);

            Console.Clear();

            int posX = 0;
            int posY = 1;

            for (int i = 0; i < (int)second; i++)
            {
                Console.SetCursorPosition(0, 0);
                Event.InvokeEventInfo($"Форматирование диска начнется через: {(int)second - i} ");
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

            Event.InvokeEventNotify("Таймер окончен");
            Event.InvokeEventEnd();
        }
    }
}
