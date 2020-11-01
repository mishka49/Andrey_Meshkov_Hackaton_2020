using System;

namespace Task3
{
    class Program
    {
        static void CheckInput(out int a)
        {
            string s;
            while(true)
            {
                s = Console.ReadLine();
                if(int.TryParse(s, out a))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Error. Try again");
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            CheckInput(out int a);
            Console.WriteLine("Заполните массив элементами кроме последнего ");
            int[] array = new int[a];
            for (int i = 0; i < array.Length - 1; i++)
            {
                CheckInput(out array[i]);
            }
            Console.WriteLine("Введите число для подстановки");
            CheckInput(out int number);
            Console.WriteLine("введите номер позиции для подстановки");
            CheckInput(out int j);
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
