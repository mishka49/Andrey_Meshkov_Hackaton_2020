using System;

namespace Princess1
{
    class Program
    {
        public enum Result
        {
            Win,
            InProgres,
            Lost,
            Yes,
            No
        }

        public static void ControlMovment(Knight knight)
        {
            ConsoleKeyInfo keyPushed = Console.ReadKey();

            switch (keyPushed.Key)
            {
                case ConsoleKey.DownArrow:
                    if ((knight.Y + 1) < Land.Field.GetLength(0))
                    {
                        knight.Y++;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if ((knight.Y - 1) >= 0)
                    {
                        knight.Y--;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if ((knight.X - 1) >= 0)
                    {
                        knight.X--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if ((knight.X + 1) < Land.Field.GetLength(1))
                    {
                        knight.X++;
                    }
                    break;
            }
        }

        public static void ShowResultOfMotion(Knight knight, Princess princess)
        {
            Console.Clear();

            for (int i = 0; i < Land.Field.GetLength(0); i++)
            {
                for (int j = 0; j < Land.Field.GetLength(1); j++)
                {
                    if (i == knight.Y && j == knight.X)
                    {
                        Console.Write(knight.Avatar);
                    }
                    else if (i == princess.Y && j == princess.X)
                    {
                        Console.WriteLine(princess.Avatar);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine("Health: " + knight.Health);
        }

        public static Result CalculateResultOfMotion(Knight knight, Princess princess)
        {
            if (knight.Health - Land.Field[knight.Y, knight.X] > 0)
            {
                knight.Health -= Land.Field[knight.Y, knight.X];
                Land.Field[knight.Y, knight.X] = 0;

                if (knight.X == princess.X && knight.Y == princess.Y)
                {
                    return Result.Lost;
                }
                else
                {
                    return Result.InProgres;
                }
            }
            else
            {
                return Result.Lost;
            }
        }

        public static Result OpenMenu(string result)
        {
            while (true)
            {
                Console.WriteLine($"Вы {result}. Попробывать еще раз?");
                Console.WriteLine("Yes or No");

                string operation = Console.ReadLine();

                if (operation == Convert.ToString(Result.Yes))
                {
                    return Result.Yes;

                }
                else if (operation == Convert.ToString(Result.No))
                {
                    Console.Clear();
                    return Result.No;
                }
                else
                {
                    Console.WriteLine("Введена неверная операция");
                }
            }
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите размер поля");
                Land land = new Land(EnterCorrectData<int>(), EnterCorrectData<int>());
                Result result;

                while (true)
                {
                    ShowResultOfMotion(land.knight, land.princess);
                    ControlMovment(land.knight);
                    result = CalculateResultOfMotion(land.knight, land.princess);
                    if (result == Result.Win)
                    {
                        result = OpenMenu("выиграли");
                        break;
                    }
                    else if (result == Result.Lost)
                    {
                        result = OpenMenu("проиграли");
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (result == Result.Yes)
                {
                    continue;
                }
                else
                {
                    return;
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
    }
}
