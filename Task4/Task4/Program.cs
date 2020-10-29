using System;

namespace Task4
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
            int a, tmp; 
            Console.WriteLine("введите размер массива");
            CheckingInput(out a);
            Random random = new Random();
            int[] array = new int[a];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 10);
            }
            Console.WriteLine("Befor Sort:");
            foreach (int z in array)
            {
                Console.Write(z);
            }
            Console.WriteLine();

            for (int j = 1; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length - j; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                    }
                }
            }
            Console.WriteLine("After sort:");
            foreach (int z in array)
            {
                Console.Write(z);
            }
            Console.ReadKey();
        }
    }
}
