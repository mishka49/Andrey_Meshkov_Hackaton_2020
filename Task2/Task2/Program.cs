using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static int CheckInput()
        {
            int value;
            while(!int.TryParse(Console.ReadLine(),out value) || value==0)
            { 
                    Console.WriteLine("Error. Try again");
            }
            return value;
        }
        static void CreatRandomArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ввведите размер массива");
            int value = CheckInput();
            int[] array = new int[value];
            CreatRandomArray(array);
            Console.WriteLine("Befor");
            foreach (int z in array)
            {
                Console.Write(z);
            }
            Console.WriteLine();
            List<int> numbers = new List<int> { };
            List<int> weights = new List<int> { };
            Array.Sort(array);
            int reps;
            for(int j=0;j<array.Length;j+=reps)
            {
                reps = 0;
                numbers.Add(array[j]);
                for (int i = j; i < array.Length; i++)
                {
                    if (array[j] == array[i])
                    {
                        reps++;
                    }
                }
                weights.Add(reps);
            }
            if (weights.Max() == 1)
            {
                Console.WriteLine("Все элементы массива встречаются не более одного раза");
            }
            else
            {
                Console.Write("элементы встречающиеся наибольшее количество раз: ");
                for (int i = 0; i < weights.Count; i++)
                {
                    if (weights[i] == weights.Max())
                    {
                        Console.Write(numbers[i] + "\t");
                    }
                }          
            }  
            Console.ReadKey();
        }
    }
}
