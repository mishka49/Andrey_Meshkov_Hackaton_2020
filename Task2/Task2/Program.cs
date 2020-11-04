using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    internal class Program
    {
        private static void SortArray(int[] array)
        {
            int tmp;
            for (int j = 1; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length-j; i++)
                {
                    if(array[i]>array[i+1])
                    {
                        tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                    }
                }
            }
        }

        private static int InputValue()
        {
            int value;
            while(!int.TryParse(Console.ReadLine(),out value) || value==0)
            { 
                    Console.WriteLine("Error. Try again");
            }
            return value;
        }

        private static void FillArrayRandomNumbers(int[] array)
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
            int value = InputValue();
            int[] array = new int[value];
            FillArrayRandomNumbers(array);
            Console.WriteLine("Befor");
            foreach (int z in array)
            {
                Console.Write(z);
            }
            Console.WriteLine();
            SortArray(array);
            int[][] weights=new int[2][];
            weights[0] = array;
            weights[1] = new int[array.Length];
            int repetition;
            for(int j=0;j<array.Length;j+= repetition)
            {
                repetition = 0;
                for (int i = j; i < array.Length; i++)
                {
                    if (array[j] == array[i])
                    {
                        repetition++;
                    }
                }
                weights[1][j]=repetition;
            }
            Console.WriteLine("Max:" + weights[1].Max());
            if (weights[1].Max() == 1)
            {
                Console.WriteLine("Все элементы массива встречаются не более одного раза");
            }
            else
            {
                Console.Write("элементы встречающиеся наибольшее количество раз: ");
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
