using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
<<<<<<< Updated upstream
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
            int a, k;
            Console.WriteLine("Ввведите размер массива");
            CheckingInput(out a);
=======
        static void CheckInput(out int a)
        {
            string s;
            bool result;
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
            int k;
            Console.WriteLine("Ввведите размер массива");
            CheckInput(out int a);
>>>>>>> Stashed changes
            Random random = new Random();
            int[] array = new int[a];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
            }
            Console.WriteLine("Befor");
            foreach (int z in array)
            {
                Console.Write(z);
            }
            Console.WriteLine();
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
            List<int> number = new List<int> { };
            List<int> weight = new List<int> { };
            Array.Sort(array);
            for(int j=0;j<array.Length;j+=k)
            {
                k = 0;
                number.Add(array[j]);
                for (int i = j; i < array.Length; i++)
                {
                    if (array[j] == array[i])
                    {
                        k++;
                    }
                }
                weight.Add(k);
            }
            int max = weight.Max();
            if (max == 1)
            {
                Console.WriteLine("Все элементы массива встречаются не более одного раза");
            }
            else
            {
                Console.Write("элементы встречающиеся наибольшее количество раз: ");
                for (int i = 0; i < weight.Count; i++)
                {
                    if (weight[i] == max)
                    {
                        Console.Write(number[i] + "\t");
                    }
                }          
            }  
            Console.ReadKey();
        }
    }
}
