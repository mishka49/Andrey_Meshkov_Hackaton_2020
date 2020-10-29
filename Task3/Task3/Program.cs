using System;

namespace Task3
{
    class Program
    {
        static bool CheckingInput(out int a)
        {
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Error. Try again");
                return CheckingInput(out a);
            }
            return true;
        }
        static void Main(string[] args)
        {
            int a, number, j;
            Console.WriteLine("Введите размер массива");
            CheckingInput(out a);
            Console.WriteLine("Заполните массив элементами кроме последнего ");
            int[] array = new int[a];
            for (int i = 0; i < array.Length - 1; i++)
            {
                CheckingInput(out array[i]);
            }
            Console.WriteLine("Введите число для подстановки");
            CheckingInput(out number);
            Console.WriteLine("введите номер позиции для подстановки");
            CheckingInput(out j);
            for (int i = array.Length - 1; i > j; i--)
            {
                array[i] = array[i - 1];
            }
            array[j] = number;
            Console.WriteLine("Массив после подстановки:");
            foreach (int z in array)
            {
                Console.Write(z);
            }
            Console.ReadKey();
        }

    }
}
