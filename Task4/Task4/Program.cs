using System;

namespace Task4
{
    internal class Program
    {
        private static int EnterIntValue()
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
            int temporaryStorage;
            Console.WriteLine("Enter the size of the array");
            int a = EnterIntValue();
            Random random = new Random();
            int[] array = new int[a];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 10);
            }

            Console.WriteLine("Befor Sort:");
            foreach (var item in array)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temporaryStorage = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temporaryStorage;
                    }
                }
            }

            Console.WriteLine("After sort:");
            foreach (var item in array)
            {
                Console.Write(item);
            }

            Console.ReadKey();
        }
    }
}
