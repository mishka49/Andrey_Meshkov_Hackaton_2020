using System;

namespace Task3
{
    internal class Program
    {
        private static int EnterInttValue()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Error. Try again");
            }
            return value;
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int size = EnterInttValue();
            Console.WriteLine("Заполните массив элементами кроме последнего ");
            int[] array = new int[size];

            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = EnterInttValue();
            }

            Console.WriteLine("Введите число для подстановки");
            int number = EnterInttValue();
            Console.WriteLine("введите номер позиции для подстановки");
            int itemNumber = EnterInttValue();

            for (int i = array.Length - 1; i > itemNumber; i--)
            {
                array[i] = array[i - 1];
            }

            array[itemNumber] = number;

            Console.WriteLine("Массив после подстановки:");
            foreach (var item in array)
            {
                Console.Write(item);
            }

            Console.ReadKey();
        }

    }
}
