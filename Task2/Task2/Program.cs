using System;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        private static void SortArray(int[] array)
        {
            int temporaryStorage;
            for (int j = 1; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length - j; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temporaryStorage = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temporaryStorage;
                    }
                }
            }
        }

        private static int EnterInttValue()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value == 0)
            {
                Console.WriteLine("Error. Try again");
            }
            return value;
        }

        private static void FillArrayWithRandomNumbers(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
            }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Ввведите размер массива");
            int value = EnterInttValue();
            int[] array = new int[value];
            FillArrayWithRandomNumbers(array);

            Console.WriteLine("Befor");
            foreach (var item in array)
            {
                Console.Write(item);
            }

            Console.WriteLine();
            SortArray(array);
            int[][] weights = new int[2][];
            weights[0] = array;
            weights[1] = new int[array.Length];
            int repetition;

            for (int i = 0; i < array.Length; i += repetition)
            {
                repetition = 0;

                for (int j = i; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        repetition++;
                    }
                }

                weights[1][i] = repetition;
            }

            if (weights[1].Max() == 1)
            {
                Console.WriteLine("Все элементы массива встречаются не более одного раза");
            }
            else
            {
                Console.Write("Элементы встречающиеся наибольшее количество раз: ");
                for (int i = 0; i < weights[1].Length; i++)
                {
                    if (weights[1][i] == weights[1].Max())
                    {
                        Console.Write(weights[0][i] + "\t");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
